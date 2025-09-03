using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Add a class-level variable to track the current player
        private string currentPlayer = "X";

        // Game mode and difficulty
        private bool isPvC = false; // false: PvP, true: PvC
        private string computerDifficulty = "Easy"; // "Easy" or "Hard"

        // List of grid button names for Tic-Tac-Toe
        private readonly string[] gridButtonNames = { "b1", "b2", "b3", "b4", "b5", "b6", "b7", "b8", "b9" };

        public Form1()
        {
            InitializeComponent();
            // Set initial turn label
            lblTurn.Text = $"Turn: {currentPlayer}";
            UpdateModeAndDifficultyButtons();
        }

        // Helper to get only grid buttons
        private IEnumerable<Button> GetGridButtons()
        {
            return Controls.OfType<Button>().Where(btn => gridButtonNames.Contains(btn.Name));
        }

        private void b1_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            // Prevent overwriting a button that has already been clicked
            if (b.Text != "")
                return;

            // Set the button text to the current player
            b.Text = currentPlayer;

            if (check_winner())
            {
                MessageBox.Show("We have a winner!");
                // Only clear grid buttons
                foreach (Button btn in GetGridButtons())
                    btn.Text = "";
                currentPlayer = "X";
                lblTurn.Text = $"Turn: {currentPlayer}";
                return;
            }

            // Switch the player for the next turn
            currentPlayer = (currentPlayer == "X") ? "O" : "X";
            lblTurn.Text = $"Turn: {currentPlayer}";

            // If PvC and it's computer's turn, run computer move
            if (isPvC && currentPlayer == "O")
            {
                ComputerMove();
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            isPvC = !isPvC;
            UpdateModeAndDifficultyButtons();
            // Reset game on mode change
            foreach (Button btn in GetGridButtons())
                btn.Text = "";
            currentPlayer = "X";
            lblTurn.Text = $"Turn: {currentPlayer}";
        }

        private void btnDifficulty_Click(object sender, EventArgs e)
        {
            computerDifficulty = (computerDifficulty == "Easy") ? "Hard" : "Easy";
            UpdateModeAndDifficultyButtons();
        }

        // Helper to update both mode and difficulty button text
        private void UpdateModeAndDifficultyButtons()
        {
            btnMode.Text = isPvC ? "Mode: PvC" : "Mode: PvP";
            btnDifficulty.Text = $"Difficulty: {computerDifficulty}";
        }

        private void ComputerMove()
        {
            // Find all empty grid buttons
            var emptyButtons = GetGridButtons().Where(btn => btn.Text == "").ToList();

            if (emptyButtons.Count == 0)
                return;

            Button moveBtn = null;

            if (computerDifficulty == "Easy")
            {
                // Random move
                var rand = new Random();
                moveBtn = emptyButtons[rand.Next(emptyButtons.Count)];
            }
            else // Hard
            {
                // Try to win or block, else random
                moveBtn = FindBestMove(emptyButtons);
                if (moveBtn == null)
                {
                    var rand = new Random();
                    moveBtn = emptyButtons[rand.Next(emptyButtons.Count)];
                }
            }

            if (moveBtn != null)
            {
                moveBtn.Text = "O";
                if (check_winner())
                {
                    MessageBox.Show("We have a winner!");
                    foreach (Button btn in GetGridButtons())
                        btn.Text = "";
                    currentPlayer = "X";
                    lblTurn.Text = $"Turn: {currentPlayer}";
                    return;
                }
                currentPlayer = "X";
                lblTurn.Text = $"Turn: {currentPlayer}";
            }
        }

        // Simple hard AI: win if possible, block if possible
        private Button FindBestMove(List<Button> emptyButtons)
        {
            // Try to win
            foreach (var btn in emptyButtons)
            {
                btn.Text = "O";
                if (check_winner())
                {
                    btn.Text = "";
                    return btn;
                }
                btn.Text = "";
            }
            // Try to block
            foreach (var btn in emptyButtons)
            {
                btn.Text = "X";
                if (check_winner())
                {
                    btn.Text = "";
                    return btn;
                }
                btn.Text = "";
            }
            return null;
        }

        private Boolean check_winner()
        {
            if (b1.Text == b2.Text && b2.Text == b3.Text && b1.Text != "")
                return true;
            if (b4.Text == b5.Text && b5.Text == b6.Text && b4.Text != "")
                return true;
            if (b7.Text == b8.Text && b8.Text == b9.Text && b7.Text != "")
                return true;
            if (b1.Text == b4.Text && b4.Text == b7.Text && b1.Text != "")
                return true;
            if (b2.Text == b5.Text && b5.Text == b8.Text && b2.Text != "")
                return true;
            if (b3.Text == b6.Text && b6.Text == b9.Text && b3.Text != "")
                return true;
            if (b1.Text == b5.Text && b5.Text == b9.Text && b1.Text != "")
                return true;
            if (b3.Text == b5.Text && b5.Text == b7.Text && b3.Text != "")
                return true;
            return false;
        }

        // Add the reset button event handler
        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Button btn in GetGridButtons())
                btn.Text = "";
            currentPlayer = "X";
            lblTurn.Text = $"Turn: {currentPlayer}";
        }
    }
}

