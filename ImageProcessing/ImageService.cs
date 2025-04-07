using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace NevermoreOrganizerAide.ImageProcessing;

public class ImageService
{
    public void AddTextToImage()
    {
        var image = Image.Load("image.png");
        const string text = "Регистрация";
        var font = SystemFonts.CreateFont("Arial", 48);
        var colour = Color.Black;
        var location = new PointF(50, 50);
    
        image.Mutate(x => x.DrawText(text, font, colour, location));
        image.Save("result.png");
    }
}
