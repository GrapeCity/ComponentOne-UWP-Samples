Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.IO

Imports D2D = C1.Util.DX.Direct2D
Imports D3D = C1.Util.DX.Direct3D11
Imports DW = C1.Util.DX.DirectWrite
Imports DXGI = C1.Util.DX.DXGI
Imports WIC = C1.Util.DX.WIC
Imports STG = C1.Util.DX.Storage
Imports C1.Util.DX

<D2D.CustomEffect("Adds the Warp effect", "Distort", "C1")>
<D2D.CustomEffectInput("Source")>
Public Class WarpEffect
    Inherits CallbackBase
    Implements D2D.CustomEffect
    Implements D2D.DrawTransform

    Const TesselationLevelsX As Integer = 200
    Const TesselationLevelsY As Integer = 120

    ' {DAEC286F-66E3-4B07-AACE-DE38A21E8A6C}
    Shared ReadOnly GUID_WarpVertexShader As New Guid(&HDAEC286FUI, &H66E3, &H4B07, &HAA, &HCE, &HDE,
        &H38, &HA2, &H1E, &H8A, &H6C)

    ' {CE40DBCB-515D-41C4-9089-DC7582888897}
    Shared ReadOnly GUID_WarpVertexBuffer As New Guid(&HCE40DBCBUI, &H515D, &H41C4, &H90, &H89, &HDC,
        &H75, &H82, &H88, &H88, &H97)

    <StructLayout(LayoutKind.Sequential)>
    Private Structure ConstantBuffer
        Public Size As Size2F
        Public StartPos As Point2F
        Public EndPos As Point2F
        Public Distance As Single
    End Structure

    ''' <summary>
    ''' Constants used to set properties for Warp custom effect.
    ''' </summary>
    Private Enum WarpProperties
        Size
        StartPos
        EndPos
        Distance
    End Enum

    Private _constBuffer As ConstantBuffer
    Private _warpStart As Point2F
    Private _warpEnd As Point2F

    Private _drawInfo As D2D.DrawInformation
    Private _inputRect As RectL
    Private _shaderBuffer As Byte()
    Private _vertexBuffer As D2D.VertexBuffer
    Private _numVertices As Integer
    Private _effect As D2D.Effect

    ''' <summary>
    ''' Initializes a new instance of <see cref="WarpEffect"/> class.
    ''' </summary>
    Public Sub New()
        _constBuffer = New ConstantBuffer() With {
            .Size = Size2F.Empty,
            .StartPos = Point2F.Empty,
            .EndPos = Point2F.Empty,
            .Distance = 0F
        }
    End Sub

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            DXUtil.Dispose(_effect)
            DXUtil.Dispose(_vertexBuffer)
            DXUtil.Dispose(_drawInfo)
        End If
        MyBase.Dispose(disposing)
    End Sub

    ''' <summary>
    ''' Gets or sets the effect objects.
    ''' </summary>
    Public Property Effect() As D2D.Effect
        Get
            Return _effect
        End Get
        Set
            Value.CustomEffect = Nothing
            _effect = Value
        End Set
    End Property

    ''' <summary>
    ''' Set the normalized [0, 1] positions of the start and end points.
    ''' </summary>
    Public Sub SetNormPositions(start As Point2F, [end] As Point2F)
        _warpStart = start
        _warpEnd = [end]
        UpdateConstants()
    End Sub

    ''' <summary>
    ''' Gets the size of the image, in pixels.
    ''' </summary>
    <D2D.PropertyBinding(D2D.BindingType.Vector2, CInt(WarpProperties.Size), "(0, 0)", "(1000000, 1000000)", "(0, 0)")>
    Public ReadOnly Property Size() As Size2F
        Get
            Return _constBuffer.Size
        End Get
    End Property

    ''' <summary>
    ''' Gets the offset of the start point, in pixels.
    ''' </summary>
    <D2D.PropertyBinding(D2D.BindingType.Vector2, CInt(WarpProperties.StartPos), "(0, 0)", "(1000000, 1000000)", "(0, 0)")>
    Public ReadOnly Property StartPosition() As Point2F
        Get
            Return _constBuffer.StartPos
        End Get
    End Property

    ''' <summary>
    ''' Gets the offset of the end point, in pixels.
    ''' </summary>
    <D2D.PropertyBinding(D2D.BindingType.Vector2, CInt(WarpProperties.EndPos), "(0, 0)", "(1000000, 1000000)", "(0, 0)")>
    Public ReadOnly Property EndPosition() As Point2F
        Get
            Return _constBuffer.EndPos
        End Get
    End Property

    ''' <summary>
    ''' Gets the pre-calculated value of the affected distance, in pixels.
    ''' </summary>
    <D2D.PropertyBinding(D2D.BindingType.Float, CInt(WarpProperties.Distance), "0", "1000000", "0")>
    Public ReadOnly Property Distance() As Single
        Get
            Return _constBuffer.Distance
        End Get
    End Property

    Private Sub UpdateConstants()
        ' exit if size is not initialized yet
        If _drawInfo Is Nothing OrElse _constBuffer.Size.IsEmpty Then
            Return
        End If

        ' pre-calculate some values
        Dim sz As Size2F = _constBuffer.Size
        Dim sp As Point2F = New Point2F(_warpStart.X * sz.Width, _warpStart.Y * sz.Height)
        Dim ep As Point2F = New Point2F(_warpEnd.X * sz.Width, _warpEnd.Y * sz.Height)

        _constBuffer.StartPos = sp
        _constBuffer.EndPos = ep
        _constBuffer.Distance = sp.Distance(ep) * 1.5F

        _drawInfo.SetVertexConstantBuffer(Of ConstantBuffer)(_constBuffer)
    End Sub

    ''' <summary>	
    ''' Creates any resources used repeatedly during subsequent rendering calls.
    ''' </summary>	
    Public Sub Initialize(effectContext As D2D.EffectContext, transformGraph As D2D.TransformGraph) Implements D2D.CustomEffect.Initialize
        If _shaderBuffer Is Nothing Then
            Dim asm As Assembly = GetType(WarpEffect).GetTypeInfo().Assembly
            Using stream As Stream = asm.GetManifestResourceStream("BitmapSamples.WarpEffect.cso")
                Dim length As Integer = CInt(stream.Length)
                _shaderBuffer = New Byte(length - 1) {}
                stream.Read(_shaderBuffer, 0, length)
            End Using
        End If
        effectContext.LoadVertexShader(GUID_WarpVertexShader, _shaderBuffer)

        _vertexBuffer = effectContext.FindVertexBuffer(GUID_WarpVertexBuffer)
        If _vertexBuffer Is Nothing Then
            Using meshStream As DataStream = GenerateMesh()
                Dim props As D2D.VertexBufferProperties = New D2D.VertexBufferProperties(1, D2D.VertexUsage.[Static], meshStream)
                Dim desc As D2D.InputElement = New D2D.InputElement("MESH_POSITION", 0, DXGI.Format.R32G32_Float, 0, 0)
                Dim custProps As D2D.CustomVertexBufferProperties = New D2D.CustomVertexBufferProperties(_shaderBuffer, New D2D.InputElement() {desc}, DXUtil.SizeOf(Of Vector2)())
                _vertexBuffer = D2D.VertexBuffer.Create(effectContext, GUID_WarpVertexShader, props, custProps)
            End Using
        End If

        transformGraph.SetSingleTransformNode(Me)
    End Sub

    Private Function GenerateMesh() As DataStream
        Dim offsetX As Single = 1.0F / TesselationLevelsX
        Dim offsetY As Single = 1.0F / TesselationLevelsY
        _numVertices = TesselationLevelsX * TesselationLevelsY * 6
        Dim stream As DataStream = New DataStream(DXUtil.SizeOf(Of Vector2)() * _numVertices, False, True)
        For i As Integer = 0 To TesselationLevelsY - 1
            For j As Integer = TesselationLevelsX - 1 To 0 Step -1
                Dim x As Single = offsetX * j
                Dim y As Single = offsetY * i
                stream.Write(New Vector2(x, y))
                stream.Write(New Vector2(x, y + offsetY))
                stream.Write(New Vector2(x + offsetX, y))
                stream.Write(New Vector2(x + offsetX, y))
                stream.Write(New Vector2(x, y + offsetY))
                stream.Write(New Vector2(x + offsetX, y + offsetY))
            Next
        Next
        Return stream
    End Function

    ''' <summary>	
    ''' Prepares an effect for the rendering process.	
    ''' </summary>	
    Public Sub PrepareForRender(changeType As D2D.ChangeType) Implements D2D.CustomEffect.PrepareForRender
        UpdateConstants()
    End Sub

    ''' <summary>	
    ''' The renderer calls this method to provide the effect implementation with a way to specify its transform graph and transform graph changes. 
    ''' It is executed when: 1) When the effect is first initialized. 2) If the number of inputs to the effect changes.
    ''' </summary>	
    Public Function SetGraph(transformGraph As D2D.TransformGraph) As Integer Implements D2D.CustomEffect.SetGraph
        Return HResult.NotImplemented.Code
    End Function

    ''' <summary>	
    ''' Sets the GPU render information for the transform.
    ''' </summary>	
    Public Sub SetDrawInfo(drawInfo As D2D.DrawInformation) Implements D2D.DrawTransform.SetDrawInfo
        _drawInfo = drawInfo
        Dim range As D2D.VertexRange = New D2D.VertexRange() With {
            .StartVertex = 0,
            .VertexCount = _numVertices
        }
        drawInfo.SetVertexProcessing(_vertexBuffer, D2D.VertexOptions.UseDepthBuffer, Nothing, range, GUID_WarpVertexShader)
    End Sub

    ''' <summary>	
    ''' Performs the inverse mapping to MapOutputRectToInputRects.
    ''' </summary>	
    Public Function MapInputRectsToOutputRect(inputRects As RectL(), inputOpaqueSubRects As RectL(), ByRef outputOpaqueSubRect As RectL) As RectL Implements D2D.DrawTransform.MapInputRectsToOutputRect
        Dim rc As RectL = inputRects(0)
        _inputRect = rc
        Dim newSize As Size2F = New Size2F(rc.Width, rc.Height)
        If _constBuffer.Size <> newSize Then
            _constBuffer.Size = newSize
            UpdateConstants()
        End If
        outputOpaqueSubRect = RectL.Empty
        Return rc
    End Function

    ''' <summary>	
    ''' Allows a transform to state how it would map a rectangle requested on its output to a set of sample rectangles on its input.
    ''' </summary>	
    Public Sub MapOutputRectToInputRects(outputRect As RectL, inputRects As RectL()) Implements D2D.DrawTransform.MapOutputRectToInputRects
        inputRects(0) = _inputRect
    End Sub

    ''' <summary>
    ''' Sets the input rectangles for this rendering pass into the transform.
    ''' </summary>
    Public Function MapInvalidRect(inputIndex As Integer, invalidInputRect As RectL) As RectL Implements D2D.DrawTransform.MapInvalidRect
        Return _inputRect
    End Function

    ''' <summary>
    ''' Gets the number of inputs to the transform node.
    ''' </summary>
    Public Function GetInputCount() As Integer Implements D2D.DrawTransform.GetInputCount
        Return 1
    End Function

End Class
