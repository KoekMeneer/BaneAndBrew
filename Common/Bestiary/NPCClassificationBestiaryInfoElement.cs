using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace BaneAndBrew.Common.Bestiary
{
    /// <summary>
    /// A single "[icon] label" Bestiary row, in the same visual family as vanilla's own
    /// biome/time rows. Icon is optional - pass null (the only option today, since nothing
    /// is registered in NPCClassificationIcons yet) and only the text renders; once real
    /// icons exist this needs no changes at all, only entries in that registry.
    /// </summary>
    public sealed class NPCClassificationBestiaryInfoElement : IBestiaryInfoElement
    {
        private const float IconSize = 20f;
        private const float IconTextGap = 6f;
        private const float RowHeight = 30f;
        private const float HorizontalPadding = 8f;

        private static readonly Color BackgroundColor = new(43, 56, 101);

        private readonly string _text;
        private readonly Asset<Texture2D>? _icon;

        public NPCClassificationBestiaryInfoElement(string text, Asset<Texture2D>? icon = null)
        {
            _text = text;
            _icon = icon;
        }

        public UIElement? ProvideUIElement(BestiaryUICollectionInfo providedInfo)
        {
            var row = new Row
            {
                Width = StyleDimension.FromPercent(.925f),
                Height = StyleDimension.FromPixels(RowHeight),
                HAlign = .5f
            };

            float textLeft = HorizontalPadding;

            if (_icon is not null)
            {
                var image = new UIImage(_icon)
                {
                    Left = StyleDimension.FromPixels(HorizontalPadding),
                    Width = StyleDimension.FromPixels(IconSize),
                    Height = StyleDimension.FromPixels(IconSize),
                    VAlign = 0.5f,
                };

                row.Append(image);
                textLeft += IconSize + IconTextGap;
            }

            var text = new UIText(_text)
            {
                Left = StyleDimension.FromPixels(textLeft),
                VAlign = 0.5f,
            };

            row.Append(text);

            return row;
        }

        /// <summary>
        /// A flat, borderless background rectangle - drawn with the same "stretch a 1x1 white
        /// pixel and tint it" technique Terraria's own UI code uses throughout, rather than
        /// any specific vanilla panel class.
        /// </summary>
        private sealed class Row : UIElement
        {
            protected override void DrawSelf(SpriteBatch spriteBatch)
            {
                CalculatedStyle dimensions = GetDimensions();
                spriteBatch.Draw(TextureAssets.MagicPixel.Value, dimensions.ToRectangle(), BackgroundColor);

                base.DrawSelf(spriteBatch);
            }
        }
    }
}