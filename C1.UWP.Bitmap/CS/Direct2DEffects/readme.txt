Direct2DEffects
----------------------------------------
Demonstrates applying Direct2D effects to the image in C1Bitmap

This sample loads an image in C1Bitmap, converts it to Direct2D
bitmap, applies various effects and draws to SurfaceImageSource.
When the user clicks the Export button the image is converted to
Direct2D bitmap, then used as the source for a Direct2D effect.
The result is imported into another instance of C1Bitmap, then
stored to a file.
