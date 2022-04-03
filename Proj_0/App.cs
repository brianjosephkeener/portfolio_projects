using System;
using Terminal.Gui;
using NStack;
using Proj_0.Models;
using Proj_0.Data;
using System.Linq;
using System.Security.Cryptography;

namespace Proj_0
{
    public static class Globals
    {
        public static int current_location = 0;
        public static bool admin = false;

    }


class App
{
    internal App()
    {

    static string rand_Str()
    {
    string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    char[] stringChars = new char[10];
    Random random = new Random();

    for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

    return new String(stringChars);
    }


            string connectionStr = "Server=tcp:brian120496.database.windows.net,1433;Initial Catalog=test_db;Persist Security Info=False;User ID=bkeener;Password=Letmein1986!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            IRepository repo = new SqlRepository(connectionStr);
            List<Employee> employees = repo.GetAllEmployees();
            List<Location> locations = repo.GetAllLocations();

            // ustring array necessary for gui to read all locations for radio group
            ustring[] locations_RG = new ustring[locations.Count];

            for (int i = 0; i < locations.Count; i++)
            {
                locations_RG[i] = ustring.Make(locations[i].GetName());
            }
            // ustring array for yes / no options
            ustring[] yes_no = new ustring[2]
            {
                "No",
                "Yes"
            };
            // ustring array for all rooms for location


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
                            new MenuItem ("_Register Guest", "", () => { if (true) RegisterGuestWin ();}),
                            new MenuItem ("_Guest Check-in", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Edit", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Check-out", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });

            MenuBar admin_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Register Guest", "", () => { if (RegisterGuestWin ()) ;}),
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

            bool RegisterGuestWin()
            {
                ClearWindow();
                List<Room> rooms = repo.GetAllRooms(Globals.current_location);

            ustring[] loc_rooms = new ustring[rooms.Count];
            for (int i = 0; i < rooms.Count; i++)
            {
                loc_rooms[i] = ustring.Make($"{rooms[i].getName()} | Vacancies: {rooms[i].getAmount()} |  Price: {rooms[i].getPrice()} | Description: {rooms[i].getDescription()}");
            }

            MenuBar employee_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Register Guest", "", () => { if (true) RegisterGuestWin ();}),
                            new MenuItem ("_Guest Check-in", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Edit", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Check-out", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });

            MenuBar admin_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Return to Main", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Register Guest", "", () => { if (RegisterGuestWin ()) ;}),
                            new MenuItem ("_Guest Check-in", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Edit", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Check-out", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Employee Actions", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });

            void Register_Complete()
            {
                ClearWindow();
                if(Globals.admin == false)
                {
                    top.Add(employee_menu);
                }
                else
                {
                    top.Add(admin_menu);
                }
            }
            MenuBar employee_menu_RG = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Return to Main", "", () => { if (true) Register_Complete();}),
                            new MenuItem ("_Guest Check-in", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Edit", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Guest Check-out", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Logout", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });
                Label currLoc = new Label($"{repo.GetLocation(Globals.current_location)}") {X = 3, Y = 3};
                Label instructions = new Label("-*- Register Guest -*-") {X = 3, Y = 6};
                Label first_name = new Label("First Name:") {X = 3, Y = 9};
                TextField first_name_t = new TextField(3, 10, 40, "");
                Label last_name = new Label("Last Name: ") {X = 3, Y = 11};
                TextField last_name_t = new TextField(3, 12, 40, "");
                Label room = new Label("Room #") {X = 3, Y = 13};
                TextField room_t = new TextField(3, 14, 40, "");
                Label credit = new Label("Credit Available: ") {X = 3, Y = 15};
                TextField credit_t = new TextField(3, 16, 40, "");
                Label confirmation_number = new Label("Confirmation Number") {X = 3, Y = 18};
                Label confirmation_number_t = new Label($"{rand_Str()}"){X = 3, Y = 19};
                Label durationofstay = new Label("Duration of Stay") {X = 3, Y = 21};
                TextField durationofstay_t = new TextField(3, 22, 40, "");
                Label checked_in = new Label("Guest Checking In?") {X = 3, Y = 23};
                RadioGroup checked_in_RG = new RadioGroup(3, 24, yes_no);
                RadioGroup room_selection = new RadioGroup(3, 27, loc_rooms);
                Button Submit_RegGuest = new Button(30, 30+rooms.Count, "Submit");
            Submit_RegGuest.Clicked += () => {
                repo.RegisterGuest(confirmation_number_t.Text.ToString(), first_name_t.Text.ToString(), last_name_t.Text.ToString(), room_t.Text.ToString(), Decimal.Parse(credit_t.Text.ToString()), Int32.Parse(durationofstay_t.Text.ToString()), Byte.Parse((checked_in_RG.SelectedItem).ToString()), Globals.current_location, room_selection.SelectedItem+1);
                Register_Complete();
            };
                win.Add(instructions, currLoc, first_name, first_name_t, last_name, last_name_t, room, room_t, credit, credit_t, confirmation_number, confirmation_number_t, durationofstay, durationofstay_t, checked_in, checked_in_RG, Submit_RegGuest, room_selection);
                top.Add(employee_menu_RG);
                return true;
            }
            

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
                Width = 40
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
                        Globals.current_location = login_rg.SelectedItem+1;
                        win.Add(new Label (3, 10, $"{Globals.current_location}"));
                        Globals.admin = false;
                    }
                    else
                    {
                        top.Add(admin_menu);
                        Globals.current_location = login_rg.SelectedItem+1;
                        Globals.admin = true;
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