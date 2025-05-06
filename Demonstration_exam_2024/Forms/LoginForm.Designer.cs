namespace Demonstration_exam_2024.Forms
{
    partial class LoginForm
    {
        // Контейнер для хранения компонентов формы
        private System.ComponentModel.IContainer components = null;

        // Метод для освобождения ресурсов формы
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Метод инициализации компонентов формы - автоматически генерируется дизайнером Windows Forms
        private void InitializeComponent()
        {
            // Создание экземпляров компонентов
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox(); // Картинка для логотипа
            this.lblLogin = new System.Windows.Forms.Label();            // Надпись "Логин"
            this.lblPassword = new System.Windows.Forms.Label();         // Надпись "Пароль"
            this.txtLogin = new System.Windows.Forms.TextBox();          // Поле ввода логина
            this.txtPassword = new System.Windows.Forms.TextBox();       // Поле ввода пароля
            this.btnLogin = new System.Windows.Forms.Button();           // Кнопка "Войти"

            // Инициализация pictureBox для логотипа
            this.pictureBoxLogo.Location = new System.Drawing.Point(100, 20);    // Позиция: x=100, y=20
            this.pictureBoxLogo.Size = new System.Drawing.Size(200, 100);        // Размер: 200x100 пикселей
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; // Режим масштабирования
            this.pictureBoxLogo.TabIndex = 0;                                    // Индекс табуляции

            // Настройка надписи "Логин"
            this.lblLogin.AutoSize = true;                              // Автоматический размер
            this.lblLogin.Location = new System.Drawing.Point(50, 140); // Позиция
            this.lblLogin.Text = "Логин:";                             // Текст надписи
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            // Настройка надписи "Пароль"
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 180);
            this.lblPassword.Text = "Пароль:";
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            // Настройка поля ввода логина
            this.txtLogin.Location = new System.Drawing.Point(120, 140);
            this.txtLogin.Size = new System.Drawing.Size(200, 23);
            this.txtLogin.TabIndex = 1;
            // Обработчик события нажатия клавиш
            this.txtLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLogin_KeyPress);

            // Настройка поля ввода пароля
            this.txtPassword.Location = new System.Drawing.Point(120, 180);
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 2;
            // Обработчик события нажатия клавиш
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);

            // Настройка кнопки входа
            this.btnLogin.Location = new System.Drawing.Point(150, 220);
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.Text = "Войти";
            this.btnLogin.TabIndex = 3;
            // Обработчик события нажатия на кнопку
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Настройки самой формы
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);    // Масштабирование
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;     // Режим масштабирования
            this.ClientSize = new System.Drawing.Size(400, 280);              // Размер окна формы
            // Добавление всех элементов управления на форму
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);              // Шрифт формы
            this.Text = "Авторизация";                                        // Заголовок окна
        }

        // Объявление приватных полей для компонентов формы
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}