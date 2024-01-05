// See https://aka.ms/new-console-template for more information
using ImagResizer;
using System.Drawing;

var img1 = System.Drawing.Image.FromFile(@"\images\DSC_3433.JPG");
var img2 = System.Drawing.Image.FromFile(@"\images\DSC_3439.JPG");

var resizedImg1 = $@"K:\InnoTechs\ImagResizer\images\{Guid.NewGuid()}DSC_3433.JPG";
var resizedImg2= $@"K:\InnoTechs\ImagResizer\images\{Guid.NewGuid()}DSC_3439.JPG";

Resizer.Rotate(img1);
Resizer.Rotate(img2);

Resizer.ResizeImage(img1, new Size(439, 702)).Save(resizedImg1);
Resizer.ResizeImage(img2, new Size(439, 702)).Save(resizedImg2);

Console.Read();
