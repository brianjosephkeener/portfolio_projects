using System;
using Terminal.Gui;
using NStack;
using Proj_0.Models;
using Proj_0.Data;
using System.Linq;

namespace Proj_0
{
class App
{
    internal App()
    {
            string connectionStr = "Server=tcp:brian120496.database.windows.net,1433;Initial Catalog=test_db;Persist Security Info=False;User ID=bkeener;Password=Letmein1986!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            IRepository repo = new SqlRepository(connectionStr);
            List<Employee> employees = repo.GetAllEmployees();
            List<Location> locations = repo.GetAllLocations();

            // ustring necessary for gui to read all locations for radio group
            ustring[] locations_RG = new ustring[locations.Count];

            for (int i = 0; i < locations.Count; i++)
            {
                locations_RG[i] = ustring.Make(locations[i].GetName());
            }
            //

            Application.Init();
            var top = Application.Top;

            // top-level window 
            var win = new Window("Front Desk Guest Management")
            {
                X = 0,
                Y = 1, 
                
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };


            top.Add(win);

            // menubar library

            MenuBar init_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; })
                        }),
                    });

            MenuBar employee_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Register Guest", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Check-in", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Edit", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Check-out", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });

            MenuBar employee_menu_RG = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Return to Main", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Check-in", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Edit", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Check-out", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });

            MenuBar admin_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Guest Register", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Check-in", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Edit", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Check-out", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Employee Actions", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });

            //
            
            top.Add(init_menu);

            // menubar function library

            static bool Quit()
            {
                var n = MessageBox.Query(50, 7, "Warning", "Are you sure you want to quit?", "Yes", "No");
                return true;
            }

            void ClearWindow()
            {
                    top.RemoveAll();
                    win.RemoveAll();
                    top.Add(win);
            }

            void RegisterGuestWin()
            {
                ClearWindow();
                Label instructions = new Label("-*- Register Guest -*-") {X = 3, Y = 2};
                win.Add(instructions);
            }
            
            //

            var login = new Label("Username: ") { X = 3, Y = 2 };
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

            // Add some controls
            RadioGroup login_rg = new RadioGroup(3, 10, locations_RG);
            Button okayB = new Button(3, 10+locations.Count+1, "Ok");
            Button cancelB = new Button(10, 10+locations.Count+1, "Cancel");
            Label sLogin = new Label (50, 2, "successful login");
            Label fLogin = new Label (50, 2, "failed login, try again");
            okayB.Clicked += () => {
                string result = repo.Login(loginText.Text.ToString(), passText.Text.ToString(), login_rg.SelectedItem+1);
                if(result != "")
                {
                    ClearWindow();
                    if(Byte.Parse(result) == 0)
                    {
                        top.Add(employee_menu);
                    }
                    else
                    {
                        top.Add(admin_menu);
                    }
                }
                else
                {
                    passText.Text = "";
                    win.Remove(fLogin);
                    win.Add(
                        new Label (50, 2, "failed login, try again")
                    );
                }
            };
            cancelB.Clicked += () => {
                loginText.Text = "";
                passText.Text = "";
            };
            win.Add(
                // The ones with layout system, Computed
                login, password, loginText, passText,
                // The ones laid out like an australopithecus, with Absolute positions:
                new Label(3, 8, "Select your hotel location before login"),
                login_rg,
                okayB,
                cancelB
            );

            

            Application.Run();
    }
}
}