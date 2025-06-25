using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static Морський_бій.Game;

namespace Морський_бій
{
    public partial class Game : Form
    {
        #region Змінні
        #region Прості змінні
        private static int cellSize = 80;
        private static int gridSize = 6;
        private static int startXforGamer = 230;
        private static int startYforGamer = 335;
        private static int startXforBot = 1230;
        private static int startYforBot = 335;
        private static int MAX_SHIPS = 10;
        private bool isHorizontal = true;
        private bool isDragging = false;
        private bool placingMode = false;
        private Ship selectedShip = null;
        private Ship draggedShip = null;
        private static int ShipPartSize = 70;
        private bool playerTurnActive = true;
        private bool allShipsConfirmed = false;
        public static bool isVisible = false;
        #endregion

        #region Lists
        private List<Ship> ships = new List<Ship>();
        private List<Ship> availableShips = new List<Ship>();
        private List<TextBox> TextBoxes = new List<TextBox>();
        private List<Ship> placedShips = new List<Ship>();
        List<Rectangle> playerGridCells = new List<Rectangle>();
        List<Rectangle> botGridCells = new List<Rectangle>();
        private List<Ship> botShips = new List<Ship>();
        private static List<List<Ship>> botShipTemplates = new List<List<Ship>>
        {
        // 🟦 Шаблон 1: Компактне розташування
        new List<Ship>
        {
            new Ship(1230, 335, 4), new Ship(1310, 415, 3), new Ship(1390, 495, 3),
            new Ship(1470, 575, 2), new Ship(1230, 655, 2), new Ship(1310, 735, 2),
            new Ship(1630, 335, 1), new Ship(1630, 735, 1), new Ship(1310, 575, 1),
            new Ship(1390, 555, 1)
        },

        // 🟦 Шаблон 2: Компактніша центральна схема
        new List<Ship>
        {
            new Ship(1230, 415, 4), new Ship(1310, 495, 3), new Ship(1390, 575, 3),
            new Ship(1470, 335, 2), new Ship(1230, 735, 2), new Ship(1310, 655, 2),
            new Ship(1390, 335, 1), new Ship(1310, 575, 1), new Ship(1230, 655, 1),
            new Ship(1470, 655, 1)
        },

        // 🟦 Шаблон 3: Верхня частина сітки
        new List<Ship>
        {
            new Ship(1230, 335, 4), new Ship(1310, 415, 3), new Ship(1390, 495, 3),
            new Ship(1470, 575, 2), new Ship(1470, 655, 2), new Ship(1230, 495, 2),
            new Ship(1310, 575, 1), new Ship(1390, 735, 1), new Ship(1310, 735, 1),
            new Ship(1230, 655, 1)
        },

        // 🟦 Шаблон 4: Компакні сходки
        new List<Ship>
        {
            new Ship(1230, 655, 4), new Ship(1310, 575, 3), new Ship(1390, 495, 3),
            new Ship(1470, 415, 2), new Ship(1230, 335, 2), new Ship(1390, 735, 2),
            new Ship(1230, 735, 1), new Ship(1390, 335, 1), new Ship(1310, 735, 1),
            new Ship(1230, 495, 1)
        },

        // 🟦 Шаблон 5: Дерево , кубік і буква Т
        new List<Ship>
        {
            new Ship(1230, 335, 4), new Ship(1310, 495, 3), new Ship(1390, 655, 3),
            new Ship(1470, 575, 2), new Ship(1230, 655, 2), new Ship(1310, 415, 2),
            new Ship(1390, 575, 1), new Ship(1230, 735, 1), new Ship(1470, 715, 1),
            new Ship(1310, 715, 1) 
        },
        // 🟦 Шаблон 6: Китайський ієрогліф
        new List<Ship>
        {
            new Ship(1230, 335, 4), new Ship(1230, 735, 3), new Ship(1470, 735, 3),
            new Ship(1550, 335, 2), new Ship(1310, 575, 2), new Ship(1470, 575, 2),
            new Ship(1230, 575, 1), new Ship(1630, 575, 1), new Ship(1550, 655, 1),
            new Ship(1310, 655, 1) 
        }
        };
        #endregion

        #region Інші

        private Dictionary<int, int> shipCounts = new Dictionary<int, int>()
        {
            { 1, 4 }, // 1-клітинкові кораблі
            { 2, 3 }, // 2-клітинкові кораблі
            { 3, 2 }, // 3-клітинкові кораблі
            { 4, 1 }  // 4-клітинкові кораблі
        };
        private Dictionary<int, int> maxShipCounts = new Dictionary<int, int>()
        {
            { 1, 4 }, // Максимум 4 одноклітинкових
            { 2, 3 }, // Максимум 3 двоклітинкових
            { 3, 2 }, // Максимум 2 триклітинкових
            { 4, 1 }  // Максимум 1 чотириклітинковий
        };
        private Dictionary<int, int> botShipCounts = new Dictionary<int, int>()
        {
            { 1, 4 }, // 1-клітинкові кораблі бота
            { 2, 3 }, // 2-клітинкові кораблі бота
            { 3, 2 }, // 3-клітинкові кораблі бота
            { 4, 1 }  // 4-клітинковий корабель бота
        };

        private bool IsInsidePlayerGrid(int x, int y)
        {
            return x >= 230 && x <= 230 + 6 * 80 && y >= 335 && y <= 335 + 6 * 80;
        }
        
        private HashSet<Point> botShots = new HashSet<Point>();
        private HashSet<Point> playerShots = new HashSet<Point>();
        private Queue<Point> targetCells = new Queue<Point>();
        
        private Random rnd = new Random();
        #endregion

        #endregion

        public Game()
        {
            InitializeComponent();
            ships.Add(new Ship(1199, 127, 1)); // Корабель на 1 клітинку
            ships.Add(new Ship(960, 127, 2)); // Корабель на 2 клітинки
            ships.Add(new Ship(621, 127, 3)); // Корабель на 3 клітинки
            ships.Add(new Ship(200, 127, 4)); // Корабель на 4 клітинки
            TextBoxes.Add(Ship1x);
            TextBoxes.Add(Ship2x);
            TextBoxes.Add(Ship3x);
            TextBoxes.Add(Ship4x);
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете вийти?", "Вихід", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете покинути/перезапустити гру?" +
                "\nПовернутися в головне меню?", 
                "Повернення в головне меню", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                ReturnToMenu();
            }
        }

        private void ReturnToMenu()
        {
            this.Dispose();
            var Menu = new Menu();
            Menu.Show();
        }
        
        public class Ship
        {
            public List<Rectangle> Parts { get; set; } = new List<Rectangle>(); // Частини корабля
            public bool IsSelected { get; set; } = false; // Чи вибраний для розміщення
            public bool IsPlaced { get; set; } = false; // Чи розміщено на полі
            public bool Destroyed { get; set; } = false; // ❗ Чи повністю знищений корабель
            public List<bool> DestroyedParts { get; set; } = new List<bool>(); // ❗ Позначка знищення кожної частини
            public int CellCount { get; set; } // Розмір корабля

            public Ship(int x, int y, int cellCount)
            {
                CellCount = cellCount;

                for (int i = 0; i < cellCount; i++)
                {
                    Parts.Add(new Rectangle(x + i * ShipPartSize, y, ShipPartSize, ShipPartSize));
                    DestroyedParts.Add(false); // ❗ Спочатку всі частини корабля не пошкоджені
                }
            }

            public void CheckDestroyed()
            {
                Destroyed = DestroyedParts.All(part => part); // ✅ Переконуємося, що всі частини знищені
                if (Destroyed)
                {
                    Console.WriteLine($"☠️ Ship ({CellCount}-cells) is now fully destroyed!");
                }
            }
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;         

            foreach (var ship in ships)
            {
                foreach (var part in ship.Parts)
                {
                    g.FillRectangle(Brushes.Blue, part); 
                    g.DrawRectangle(Pens.Blue, part);  
                }
            }

            // Заповнюємо список квадратів для сітки гравця
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    playerGridCells.Add(new Rectangle(startXforGamer + col * cellSize, startYforGamer + row * cellSize, cellSize, cellSize));
                }
            }

            // Заповнюємо список квадратів для сітки бота
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    botGridCells.Add(new Rectangle(startXforBot + col * cellSize, startYforBot + row * cellSize, cellSize, cellSize));
                }
            }

            // Малюємо клітинки гравця
            foreach (var cell in playerGridCells)
            {
                g.DrawRectangle(Pens.Black, cell);
            }

            // Малюємо клітинки бота
            foreach (var cell in botGridCells)
            {
                g.DrawRectangle(Pens.Black, cell);
            }

            // **Додаємо малювання перетягуваного корабля**
            if (draggedShip != null)
            {
                foreach (var part in draggedShip.Parts)
                {
                    g.FillRectangle(Brushes.LightBlue, part); // Напівпрозорий, щоб видно було при перетягуванні
                    g.DrawRectangle(Pens.Black, part);
                }
            }

        }

        #region Перевірки розташування кораблів

        private Rectangle GetNearestCell(Point position, List<Rectangle> gridCells)
        {
            return gridCells.OrderBy(cell => Math.Abs(cell.X - position.X) + Math.Abs(cell.Y - position.Y)).First();
        }

        private void SnapToGrid(Ship ship)
        {
            List<Rectangle> snappedParts = new List<Rectangle>();

            for (int i = 0; i < ship.Parts.Count; i++)
            {
                Rectangle nearestCell = GetNearestCell(ship.Parts[i].Location, playerGridCells); // Беремо найближчу клітинку

                if (i == 0)
                {
                    ship.Parts[i] = new Rectangle(nearestCell.X, nearestCell.Y, 80, 80);
                }
                else
                {
                    if (isHorizontal)
                    {
                        ship.Parts[i] = new Rectangle(ship.Parts[i - 1].X + 80, ship.Parts[i - 1].Y, 80, 80);
                    }
                    else
                    {
                        ship.Parts[i] = new Rectangle(ship.Parts[i - 1].X, ship.Parts[i - 1].Y + 80, 80, 80);
                    }
                }

                snappedParts.Add(ship.Parts[i]);
            }

            ship.Parts = snappedParts;
        }

        private bool IsInsidePlayerGrid(Ship ship)
        {
            foreach (var part in ship.Parts)
            {
                bool insideAnyCell = playerGridCells.Any(cell => cell.IntersectsWith(part)); // Зміна Contains() на IntersectsWith()

                if (!insideAnyCell)
                {
                    return false; // Якщо хоча б один блок корабля виходить за межі - не ставимо
                }
            }
            return true;
        }

        private bool CanPlaceShip(Ship ship)
        {
            foreach (var part in ship.Parts)
            {
                bool insideAnyCell = playerGridCells.Any(cell => cell.Contains(part.Location));
                bool overlapsWithOtherShip = ships.Any(existingShip => existingShip.Parts.Any(p => p.IntersectsWith(part)));

                if (!insideAnyCell || overlapsWithOtherShip) // Якщо виходить або накладається
                {
                    return false;
                }
            }
            return true;
        }

        private Rectangle GetShipBounds(Ship ship)
        {
            int minX = ship.Parts.Min(p => p.X);
            int minY = ship.Parts.Min(p => p.Y);

            int width = isHorizontal ? ship.Parts.Count * ShipPartSize : ShipPartSize;
            int height = isHorizontal ? ShipPartSize : ship.Parts.Count * ShipPartSize;

            return new Rectangle(minX - 10, minY - 10, width + 20, height + 20);
        }

        #endregion

        private void Game_MouseDown(object sender, MouseEventArgs e)
        {
            if (!placingMode) // Перший клік -> вибір корабля
            {
                foreach (var ship in ships)
                {
                    if (ship.IsPlaced) continue; // Пропускаємо встановлені кораблі
                    if (shipCounts[ship.CellCount] <= 0) continue; // ❌ Якщо кількість 0 — не можна вибрати

                    foreach (var part in ship.Parts)
                    {
                        if (part.Contains(e.Location))
                        {
                            draggedShip = new Ship(e.Location.X, e.Location.Y, ship.CellCount);
                            placingMode = true;
                            return;
                        }
                    }
                }
            }

            else // Другий клік -> встановлення корабля
            {
                if (draggedShip != null)
                {
                    SnapToGrid(draggedShip);

                    if (CanPlaceShip(draggedShip))
                    {
                        draggedShip.IsPlaced = true;
                        ships.Add(draggedShip);
                        shipCounts[draggedShip.CellCount]--;
                        UpdateShipCountUI(draggedShip.CellCount); // ✅ Табло оновлюється тут
                        draggedShip = null;
                    }
                    else
                    {
                        int cellCount = draggedShip.CellCount;
                        draggedShip = null;
                        shipCounts[cellCount]++;
                        UpdateShipCountUI(cellCount); // ✅ Оновлюємо табло тут теж
                    }

                    placingMode = false; // Завершуємо розміщення
                    this.Invalidate();
                }
            }
            
            if (!allShipsConfirmed && ships.Count(ship => ship.IsPlaced) == MAX_SHIPS) // ❌ Перевіряємо, чи вже підтверджено
            {
                allShipsConfirmed = true; // Позначаємо, що підтвердження вже відбулося
                ConfirmAllShips();
            }

            return;
        }

        private void UpdateShipCountUI(int cellCount)
        {
            if (!maxShipCounts.ContainsKey(cellCount)) return;
            if (!shipCounts.ContainsKey(cellCount)) return;

            // Рахуємо кількість вже розміщених кораблів
            int placedShipsCount = ships.Count(ship => ship.IsPlaced && ship.CellCount == cellCount);

            // Обмежуємо загальну кількість, щоб вона не перевищувала ліміт
            shipCounts[cellCount] = Math.Max(0, Math.Min(shipCounts[cellCount], maxShipCounts[cellCount] - placedShipsCount));

            int index = cellCount - 1;

            TextBoxes[index].Text = $"{cellCount}x/{shipCounts[cellCount]}";
            Console.WriteLine(cellCount);

            // Візуалізація залишку кораблів
            if (shipCounts[cellCount] == 0)
            {
                TextBoxes[index].BackColor = Color.White;
            }
            else
            {
                TextBoxes[index].BackColor = Color.Blue;
            }
        }

        private void Game_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedShip?.Parts == null) return;

            Rectangle previousBounds = GetShipBounds(draggedShip);

            int startX = e.Location.X;
            int startY = e.Location.Y;

            for (int i = 0; i < draggedShip.Parts.Count; i++)
            {
                draggedShip.Parts[i] = new Rectangle(
                    startX + (isHorizontal ? i * ShipPartSize : 0),
                    startY + (isHorizontal ? 0 : i * ShipPartSize),
                    ShipPartSize, ShipPartSize
                );
            }

            this.Invalidate(Rectangle.Union(previousBounds, GetShipBounds(draggedShip)));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.R)
            {
                isHorizontal = !isHorizontal; // Перемикаємо орієнтацію
                Console.WriteLine($"Орієнтація змінена: {(isHorizontal ? "Horizontal" : "Vertical")}");

                // ✅ Спочатку зміна координат корабля
                int startX = draggedShip.Parts[0].X;
                int startY = draggedShip.Parts[0].Y;

                for (int i = 0; i < draggedShip.Parts.Count; i++)
                {
                    if (isHorizontal)
                    {
                        draggedShip.Parts[i] = new Rectangle(startX + i * ShipPartSize, startY, ShipPartSize, ShipPartSize);
                    }
                    else
                    {
                        draggedShip.Parts[i] = new Rectangle(startX, startY + i * ShipPartSize, ShipPartSize, ShipPartSize);
                    }
                }

                this.Refresh();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ConfirmAllShips()
        {
            placedShips.Clear();
            placedShips = ships.Where(ship => ship.IsPlaced).ToList();

            DialogResult result = MessageBox.Show("Всі кораблі виставлено! Почати бій?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                StartBattle(); // Починаємо бій!
            }
        }

        #region Знаки та позначення

        private void DrawDestroyedLine(Graphics g, Ship ship)
        {
            if (!ship.Destroyed) return;

            Point start = new Point(ship.Parts.First().X + cellSize / 2, ship.Parts.First().Y + cellSize / 2);
            Point end = new Point(ship.Parts.Last().X + cellSize / 2, ship.Parts.Last().Y + cellSize / 2);

            g.DrawLine(new Pen(Color.Black, 5), start, end);
        }

        private void DrawHitSymbol(Graphics g, int x, int y, bool hit)
        {
            if (hit)
            {
                // ❌ Малюємо хрестик для попадання
                g.DrawLine(new Pen(Color.Red, 3), x - 10, y - 10, x + 10, y + 10);
                g.DrawLine(new Pen(Color.Red, 3), x + 10, y - 10, x - 10, y + 10);
            }
            else
            {
                // ⭕ Малюємо нолик для промаху
                g.DrawEllipse(new Pen(Color.White, 3), x - 10, y - 10, 20, 20);
            }
        }

        private void DrawHitSymbolofFullDestroy(Graphics g, int cellX, int cellY, bool singleDestroyed)
        {
            if (singleDestroyed)
            {
                // ⚫ Чорний хрестик для одиничного знищеного корабля
                g.DrawLine(new Pen(Color.Black, 5), cellX - 10, cellY - 10, cellX + 10, cellY + 10);
                g.DrawLine(new Pen(Color.Black, 5), cellX + 10, cellY - 10, cellX - 10, cellY + 10);
            }
        }

        private Point GetCellCenter(Rectangle cell)
        {
            int centerX = cell.X + cellSize / 2;
            int centerY = cell.Y + cellSize / 2;

            return new Point(centerX, centerY); // 📌 Чіткий центр клітинки
        }

        #endregion

        #region Початок та кінець гри

        private void StartBattle()
        {
            MessageBox.Show("Бій розпочався! Бот готується до атаки.", "Бій", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            PlaceBotShips(); // Бот розміщує кораблі перед початком
            GameLoop(); // Починаємо битву
        }

        private void GameLoop()
        {
            if (IsGameOver()) ReturnToMenu(); 

            playerTurnActive = true; // Гравець отримує право на постріл
        }

        private bool IsGameOver()
        {
            Console.WriteLine("\n--🔍 Checking if the game is over...--");

            // 🔄 Фільтруємо кораблі гравця та бота, які **реально розміщені**
            List<Ship> playerShips = ships.Where(ship => ship.IsPlaced).ToList();

            bool botLost = botShips.Count > 0 && botShips.All(ship => ship.Destroyed);
            bool playerLost = playerShips.Count > 0 && playerShips.All(ship => ship.Destroyed);

            Console.WriteLine("📍 Checking bot's ships:");
            foreach (var ship in botShips)
            {
                Console.WriteLine($"Ship ({ship.CellCount}-cells) Destroyed: {ship.Destroyed}");
            }

            Console.WriteLine("Bot lost?: {botLost}");
            Console.WriteLine("Player lost?: {playerLost}");

            if (botLost)
            {
                Console.WriteLine("🏆 Victory! All bot ships destroyed!");
                MessageBox.Show("🎉 Перемога! Всі ворожі кораблі було знищено!", "Кінець гри", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReturnToMenu();
                return true;
            }

            if (playerLost)
            {
                Console.WriteLine("💀 Defeat... All player ships destroyed.");
                MessageBox.Show("💀 Поразка... Всі ваші кораблі було знищено.", "Кінець гри", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReturnToMenu();
                return true;
            }

            return false;
        }

        #endregion

        #region Логіка бота

        private void BotShoot()
        {
            List<Point> availableShots = new List<Point>();

            // 🔄 Очищаємо список перед кожним пострілом!
            availableShots.Clear();

            List<Ship> playerShips = ships.Where(ship => ship.IsPlaced).ToList();

            // ✅ Формуємо новий список доступних клітинок
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Point shotPoint = new Point(startXforGamer + col * cellSize, startYforGamer + row * cellSize);
                    if (!playerShots.Contains(shotPoint) && !botShots.Contains(shotPoint)) // ❌ Перевіряємо і ботівські постріли!
                    {
                        availableShots.Add(shotPoint);
                    }
                }
            }

            if (availableShots.Count == 0)
            {
                Console.WriteLine("⚠️ No available shots left!");
                return; // Якщо всі точки зайняті, вихід
            }

            // 🎯 Обираємо випадкову доступну точку
            Point targetPoint = availableShots[rnd.Next(availableShots.Count)];

            Console.WriteLine($"🤖 Bot shoots at ({targetPoint.X}, {targetPoint.Y})");

            bool singleDestroyed = false;
            bool hit = false;

            foreach (var ship in playerShips)
            {
                for (int i = 0; i < ship.Parts.Count; i++)
                {
                    if (ship.Parts[i].Contains(targetPoint))
                    {
                        Console.WriteLine($"🔥 Bot hit player's {ship.CellCount}-cell ship!");
                        ship.DestroyedParts[i] = true;
                        hit = true;
                        ship.CheckDestroyed();

                        if (ship.Destroyed)
                        {
                            using (Graphics g = this.CreateGraphics())
                            {
                                DrawDestroyedLine(g, ship);
                                singleDestroyed = ship.Destroyed && ship.CellCount == 1;
                            }
                            Console.WriteLine($"☠️ Player's {ship.CellCount}-cell ship completely destroyed!");
                        }
                    }
                }
            }

            // ✅ Видаляємо точку з списку доступних пострілів (щоб бот більше не стріляв сюди)
            availableShots.Remove(targetPoint);

            using (Graphics g = this.CreateGraphics())
            {
                DrawHitSymbol(g, targetPoint.X + cellSize / 2, targetPoint.Y + cellSize / 2, hit);
                DrawHitSymbolofFullDestroy(g, targetPoint.X + cellSize / 2, targetPoint.Y + cellSize / 2, singleDestroyed);
            }

            // 🟢 Записуємо постріл бота
            botShots.Add(targetPoint);
        }

        private void PlaceBotShips()
        {
            Graphics g = this.CreateGraphics();
            botShips.Clear();
            isHorizontal = true;

            // 🎲 Вибір випадкового шаблону
            int templateIndex = rnd.Next(botShipTemplates.Count);
            var selectedTemplate = botShipTemplates[templateIndex];

            Console.WriteLine($"🔄 Using Bot Ship Template {templateIndex + 1}");

            foreach (var ship in selectedTemplate)
            {
                SnapBotShipsToGrid(ship); // 📌 Вирівнюємо корабель

                if (ship.CellCount == 1)
                {
                    Rectangle nearestCell = GetNearestCell(ship.Parts[0].Location, botGridCells);
                    ship.Parts[0] = new Rectangle(nearestCell.X, nearestCell.Y, cellSize, cellSize);
                }

                if (IsInsideBotGrid(ship) && CanPlaceBotShip(ship))
                {
                    botShips.Add(ship);

                    // 🟦 Виводимо координати кожного корабля
                    Console.WriteLine($"✅ Placed {ship.CellCount}-cell ship at ({ship.Parts[0].X}, {ship.Parts[0].Y})");

                    if (isVisible) // 🎨 Малюємо корабель, якщо `isVisible = true`
                    {
                        foreach (var part in ship.Parts)
                        {
                            g.FillRectangle(Brushes.Blue, new Rectangle(part.X, part.Y, cellSize, cellSize));
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"❌ Ship ({ship.CellCount}-cells) was OUTSIDE the grid or overlapping and not placed.");
                }
            }

            Console.WriteLine($"🔍 Bot ships placed: {botShips.Count}");
        }

        private bool IsInsideBotGrid(Ship ship)
        {
            foreach (var part in ship.Parts)
            {
                bool insideAnyCell = botGridCells.Any(cell => cell.IntersectsWith(part));

                if (!insideAnyCell)
                {
                    return false; // ❌ Якщо хоча б одна частина корабля виходить за межі бота
                }
            }
            return true;
        }

        private void SnapBotShipsToGrid(Ship ship)
        {
            List<Rectangle> snappedParts = new List<Rectangle>();

            for (int i = 0; i < ship.Parts.Count; i++)
            {
                Rectangle nearestCell = GetNearestCell(ship.Parts[i].Location, botGridCells); // 📌 Беремо найближчу клітинку бота

                if (i == 0)
                {
                    ship.Parts[i] = new Rectangle(nearestCell.X, nearestCell.Y, cellSize, cellSize);
                }
                else
                {
                    if (isHorizontal)
                    {
                        ship.Parts[i] = new Rectangle(ship.Parts[i - 1].X + cellSize, ship.Parts[i - 1].Y, cellSize, cellSize);
                    }
                    else
                    {
                        ship.Parts[i] = new Rectangle(ship.Parts[i - 1].X, ship.Parts[i - 1].Y + cellSize, cellSize, cellSize);
                    }
                }

                snappedParts.Add(ship.Parts[i]);
            }

            ship.Parts = snappedParts;
        }

        private Point AlignShotToGrid(Point shotPoint)
        {
            int alignedX = startXforBot + ((shotPoint.X - startXforBot) / cellSize) * cellSize;
            int alignedY = startYforBot + ((shotPoint.Y - startYforBot) / cellSize) * cellSize;
            return new Point(alignedX, alignedY);
        }

        private bool CanPlaceBotShip(Ship ship)
        {
            foreach (var part in ship.Parts)
            {
                bool insideAnyCell = botGridCells.Any(cell => cell.Contains(part.Location));
                bool overlapsWithOtherShip = botShips.Any(existingShip => existingShip.Parts.Any(p => p.IntersectsWith(part)));

                if (!insideAnyCell || overlapsWithOtherShip) // ❌ Якщо виходить або накладається
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Логіка гри гравця

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            if (!playerTurnActive) return;

            foreach (var cell in botGridCells)
            {
                if (cell.Contains(e.Location))
                {
                    Point cellCenter = GetCellCenter(cell);

                    if (playerShots.Any(shot => shot.X == cellCenter.X && shot.Y == cellCenter.Y))
                    {
                        Console.WriteLine($"🟢 Checking if ({cellCenter.X}, {cellCenter.Y}) is already fired...");
                        foreach (var shot in playerShots)
                        {
                            Console.WriteLine($" - Previous shot at ({shot.X}, {shot.Y})");
                        }
                        Console.WriteLine($"⚠️ Player already fired at ({cellCenter.X}, {cellCenter.Y}). Try another cell!");
                        return;
                    }

                    playerShots.Add(cellCenter); 

                    Console.WriteLine($"🎯 Player fire at: ({cellCenter.X}, {cellCenter.Y})");

                    bool singleDestroyed = false;
                    bool hit = false;

                    foreach (var ship in botShips)
                    {
                        for (int i = 0; i < ship.Parts.Count; i++)
                        {
                            if (ship.Parts[i].Contains(e.Location))
                            {
                                Console.WriteLine($"🔥 Hit! Ship ({ship.CellCount}-cells) part destroyed.");
                                ship.DestroyedParts[i] = true;
                                hit = true;

                                ship.CheckDestroyed();

                                singleDestroyed = ship.Destroyed && ship.CellCount == 1;

                                

                                if (ship.Destroyed)
                                {
                                    using (Graphics g = this.CreateGraphics())
                                    {
                                        DrawDestroyedLine(g, ship);
                                    }
                                    Console.WriteLine($"☠️ Ship ({ship.CellCount}-cells) completely destroyed!");
                                }
                            }
                        }
                    }

                    using (Graphics g = this.CreateGraphics())
                    {
                        DrawHitSymbol(g, cellCenter.X, cellCenter.Y, hit);
                        DrawHitSymbolofFullDestroy(g, cellCenter.X, cellCenter.Y, singleDestroyed);
                    }

                    playerTurnActive = false;
                    BotShoot();
                    playerTurnActive = true;
                    if (IsGameOver()) return;
                    return;
                }
            }
        }

        #endregion
    }
}
