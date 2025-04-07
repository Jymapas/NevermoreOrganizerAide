using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace NevermoreOrganizerAide.ImageProcessing;

public class ImageService(Font font)
{
    private const string ImagePath = "image.png";
    private const string ResultPath = "result.png";
    private readonly PointF _position = new(50, 50);
    private readonly Color _strokeColour = Color.Black;
    private readonly Color _textColour = Color.White;

    public ImageService() : this(SystemFonts.CreateFont("Arial", 48)) { }

    public void AddTextToImage(string text)
    {
        var image = Image.Load(ImagePath);
        image.Mutate(x => x.DrawText(text, font, _textColour, _position));
        image.Save(ResultPath);
    }
}
