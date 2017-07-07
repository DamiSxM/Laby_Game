using System.Drawing;
using System.Windows.Forms;
using Laby_Interfaces;
using Laby_Maze;
using Laby_Affichage;
using Laby_Reseau;
using Laby_Gestion;

namespace Laby_GameSERVER
{
    public partial class GameSERVER : Form
    {
        Maze Labyrinthe;
        LabyPanel Affichage;
        Reseau Liaison;
        Gestion Gestion;
        public GameSERVER()
        {
            InitializeComponent();

            Labyrinthe = new Maze(51);

            Affichage = new LabyPanel(Labyrinthe.Labyrinthe);
            Affichage.Location = new Point(0, 0);
            Controls.Add(Affichage);

            Liaison = new Reseau(Etat.SERVER);

            Gestion = new Gestion(Labyrinthe, Affichage, Liaison);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Affichage.PersoMove(Direction.LEFT); break;
                case Keys.Up:
                    Affichage.PersoMove(Direction.UP); break;
                case Keys.Right:
                    Affichage.PersoMove(Direction.RIGHT); break;
                case Keys.Down:
                    Affichage.PersoMove(Direction.DOWN); break;
                case Keys.A:
                    Affichage.ItemAdd(3, 3, "porte1"); break;
                case Keys.Z:
                    Affichage.ItemRemove(3, 3); break;
                case Keys.E:
                    Affichage.ItemAdd(4, 4, "GrilleFermee"); break;
                case Keys.Q:
                    Affichage.PlayerAdd("bob", 5, 5); break;
                case Keys.S:
                    Affichage.PlayerMove("bob", 5, 4); break;
                case Keys.D:
                    Affichage.PlayerRemove("bob"); break;
                case Keys.NumPad0:
                    Affichage.Warfog(0); break;
                case Keys.NumPad1:
                    Affichage.Warfog(1); break;
                case Keys.NumPad2:
                    Affichage.Warfog(2); break;
                case Keys.NumPad3:
                    Affichage.Warfog(3); break;
                case Keys.NumPad4:
                    Affichage.Warfog(4); break;
                case Keys.D1:
                    Affichage.PersoTeleport(0, 0); break;
                case Keys.D2:
                    Affichage.PersoTeleport(1, 1); break;
                case Keys.D3:
                    Affichage.PersoTeleport(3, 3); break;
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            Affichage.PersoStop();
        }
    }
}
