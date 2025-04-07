using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace NevermoreOrganizerAide.ImageProcessing;

public class ImageService
{
    private readonly Font _font = SystemFonts.CreateFont("Arial", 48);

    public void AddTextToImage(string text)
    {
        var image = Image.Load("image.png");
        var colour = Color.Black;
        var location = new PointF(50, 50);

        image.Mutate(x => x.DrawText(text, _font, colour, location));
        image.Save("result.png");
    }
}
