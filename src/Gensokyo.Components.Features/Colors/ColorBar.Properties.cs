using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gensokyo.Components.Colors
{
    partial class ColorBar
    {
        public static readonly DependencyPropertyKey BrushPropertyKey;
        public static readonly DependencyProperty BrushProperty;
        public static readonly DependencyPropertyKey ColorPropertyKey;
        public static readonly DependencyProperty ColorProperty;
        public static readonly DependencyPropertyKey RPropertyKey;
        public static readonly DependencyProperty RProperty;
        public static readonly DependencyPropertyKey GPropertyKey;
        public static readonly DependencyProperty GProperty;
        public static readonly DependencyPropertyKey BPropertyKey;
        public static readonly DependencyProperty BProperty;

        /// <summary>
        /// 获取当前表示的红色分量值。
        /// </summary>
        public double R
        {
            get => (double)GetValue(RProperty);
        }


        /// <summary>
        /// 获取当前表示的绿色分量值。
        /// </summary>
        public double G
        {
            get => (double)GetValue(GProperty);
        }


        /// <summary>
        /// 获取当前表示的蓝色分量值。
        /// </summary>
        public double B
        {
            get => (double)GetValue(BProperty);
        }

        /// <summary>
        /// 获取当前表示的画刷。
        /// </summary>
        public Brush Brush
        {
            get => (Brush)GetValue(BrushProperty);
        }

        /// <summary>
        /// 获取当前表示的颜色。
        /// </summary>
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
        }
    }
}
