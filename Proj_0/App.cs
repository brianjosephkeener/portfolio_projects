using Terminal.Gui;
using NStack;

class App
{
    internal App()
    {
            Application.Init();
            var top = Application.Top;

            // Creates the top-level window to show
            var win = new Window("Front Desk Guest Management")
            {
                X = 0,
                Y = 1, 
                
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            top.Add(win);

            // Creates a menubar, the item "New" has a help menu.
            var menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Register New Employee","", null),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; })
                        }),
                    });
            top.Add(menu);

            static bool Quit()
            {
                var n = MessageBox.Query(50, 7, "Warning!", "Are you sure you want to quit?", "Yes", "No");
                return n == 0;
            }

            var login = new Label("Login: ") { X = 3, Y = 2 };
            var password = new Label("Password: ")
            {
                X = Pos.Left(login),
                Y = Pos.Top(login) + 2
            };
            var loginText = new TextField("")
            {
                X = Pos.Right(password),
                Y = Pos.Top(login),
                Width = 40
            };
            var passText = new TextField("")
            {
                Secret = true,
                X = Pos.Left(loginText),
                Y = Pos.Top(password),
                Width = Dim.Width(loginText)
            };

            // Add some controls, 
            win.Add(
                // The ones with my favorite layout system, Computed
                login, password, loginText, passText,

                // The ones laid out like an australopithecus, with Absolute positions:
                new CheckBox(3, 6, "Remember me", true),
                new Button(3, 8, "Ok"),
                new Button(10, 8, "Cancel"),
                new Label(3, 12, "Press F9 or ESC plus 9 to activate the menubar")
            );

            Application.Run();
    }
}