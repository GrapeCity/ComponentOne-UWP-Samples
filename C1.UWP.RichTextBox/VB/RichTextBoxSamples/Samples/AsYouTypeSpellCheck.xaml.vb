Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports C1.Xaml.SpellChecker
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System


Partial Public NotInheritable Class AsYouTypeSpellCheck
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        rtb.Text = Strings.SpellCheck
        Dim spell As New C1SpellChecker()
        rtb.SpellChecker = spell
        Dim asm As Assembly = GetType(DemoRtfFilter).GetTypeInfo().Assembly
        Dim stream As Stream = asm.GetManifestResourceStream("RichTextBoxSamples.C1Spell_en-US.dct")
        spell.MainDictionary.Load(stream)
    End Sub
End Class