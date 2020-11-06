CustomLocalization
-----------------------------------------------------------------------------
Shows how to add custom localizable resources for C1 UWP controls.

This application shows the same features as SchedulerSamples application. But it uses Russian culture and 2 customized Russian translations.
To include custom translation for resources defined in C1 UPW assemblies, you should do the next:
- find default localization resources shipped with controls in the Help\LocalizationResources.zip file;
- copy file which you want to localize to your application folder and include it into application;
- don't change file name, only make sure you added correct languege suffix, for example, lang-ru, before resw extension;
- edit file;
- change application default language to desired culture.