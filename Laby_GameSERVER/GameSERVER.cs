using System.Drawing;
using System.Windows.Forms;
/*using Laby_Interfaces;
using Laby_Maze;
using Laby_Affichage;
using Laby_Reseau;
using Laby_Gestion;*/
using Labyrinthe;

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

            Affichage = new LabyPanel(Labyrinthe);
            Affichage.Location = new Point(0, 0);
            Controls.Add(Affichage);
            
            Liaison = new Reseau(); //Liaison = new Reseau(Etat.SERVER);

            Gestion = new Gestion(Labyrinthe, Affichage, Liaison);
            Gestion.Start(Etat.SERVER);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Gestion.PersoMove(Direction.LEFT); break;
                case Keys.Up:
                    Gestion.PersoMove(Direction.UP); break;
                case Keys.Right:
                    Gestion.PersoMove(Direction.RIGHT); break;
                case Keys.Down:
                    Gestion.PersoMove(Direction.DOWN); break;
                case Keys.A:
                    Gestion.ItemAdd(new Point(3, 3), Loot.CRATE); break;
                case Keys.Z:
                    Gestion.ItemRemove(new Point(3, 3)); break;
                case Keys.E:
                    Gestion.ItemAdd(new Point(4, 4), Loot.COIN); break;
                case Keys.Q:
                    Gestion.PlayerAdd("bob", new Point(5, 5)); break;
                case Keys.S:
                    Gestion.PlayerMove("bob", new Point(5, 4)); break;
                case Keys.D:
                    Gestion.PlayerRemove("bob"); break;
                case Keys.NumPad0:
                    Affichage.WarfogSet(0); break;
                case Keys.NumPad1:
                    Affichage.WarfogSet(1); break;
                case Keys.NumPad2:
                    Affichage.WarfogSet(2); break;
                case Keys.NumPad3:
                    Affichage.WarfogSet(3); break;
                case Keys.NumPad4:
                    Affichage.WarfogSet(4); break;
                case Keys.D1:
                    Gestion.PersoTeleport(new Point(0, 0)); break;
                case Keys.D2:
                    Gestion.PersoTeleport(new Point(1, 1)); break;
                case Keys.D3:
                    Gestion.PersoTeleport(new Point(3, 3)); break;
                case Keys.PageUp:
                    Gestion.PersoVitesse++; break;
                case Keys.PageDown:
                    Gestion.PersoVitesse--; break;
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            Affichage.PersoStop();
        }

        private void GameSERVER_FormClosing(object sender, FormClosingEventArgs e)
        {
            Liaison.Close();
        }
    }
}