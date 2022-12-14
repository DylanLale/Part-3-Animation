using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_3__Animation
{ }

    public class tribble
{
    private Texture2D _texture;
    private Rectangle _rect;
    private Vector2 _speed;


    public tribble(Texture2D texture, Rectangle rectangle, Vector2 speed)
    {
        _texture = texture;
        _rect = rectangle;
        _speed = speed;
    }

    public void Move()
    {
        _rect.Offset(_speed);
    }

    public void BounceLeftRight()
    {
        _speed.X *= -1;
    }

    public void BounceTopBottom()
    {
        _speed.Y *= -1;
    }

    public Rectangle Bounds
    {
        get { return _rect; }
        set { _rect = value; }
    }

    public Texture2D Texture
    {
        get { return _texture; }
    }

}
    
