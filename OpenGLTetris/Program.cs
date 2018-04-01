using System.Windows.Forms;

namespace OpenGLTetris
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageBox.Show("Strzałki w lewo i w prawo - przesuwanie spadającego klocka; " +
                "Spacja - obracanie klocka; R - reset", "Info - Keyboard");

            using (var window = new Window())
            {
                window.Run(2, 60);
            }
        }
    }
}
