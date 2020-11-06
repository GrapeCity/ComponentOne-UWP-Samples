using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using C1.Xaml.SpellChecker;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RichTextBoxSamples
{
    public sealed partial class AsYouTypeSpellCheck : Page
    {
        public AsYouTypeSpellCheck()
        {
            this.InitializeComponent();
            rtb.Text = Strings.SpellCheck;
            var spell = new C1SpellChecker();
            rtb.SpellChecker = spell;
            Assembly asm = typeof(DemoRtfFilter).GetTypeInfo().Assembly;
            Stream stream = asm.GetManifestResourceStream("RichTextBoxSamples.Resources.C1Spell_en-US.dct");
            spell.MainDictionary.Load(stream);
        }
    }
}
