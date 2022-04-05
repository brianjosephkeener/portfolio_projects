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
            
            Loggout();

            static bool Quit()
            {
                var n = MessageBox.Query(50, 7, "Warning", "Are you sure you want to quit?", "Yes", "No");
                if(n == 1)
                {
                    return false;
                }
                return true;
            }

            void EmployeeScreen()
            {
                        Label GuestS = new Label(3, 4, "Guest Lookup");
                        TextField GuestS_t = new TextField(3, 3, 40, "");
                        Button Search = new Button(3, 6, "Search");
                        List<Label> tempcontainer = new List<Label>();
                        List<Button> tempcontainer_B = new List<Button>();
                        Search.Clicked += () => 
                        {
                            if(GuestS_t.Text.ToString() == "")
                            {
                                win.RemoveAll();
                                win.Add(GuestS, GuestS_t, Search);
                                tempcontainer.Clear();
                                List<Guest> guestresult = repo.GuestAll(Globals.current_location);
                            ustring[] guestsresultarr = new ustring[guestresult.Count];
                                for (int i = 0; i < guestresult.Count; i++)
                                {
                                    guestsresultarr[i] = ustring.Make($"Name: {guestresult[i].getFirstName()} {guestresult[i].getLastName()} | Room: {guestresult[i].getRoom()} | Credits Remaining: {guestresult[i].getCredit()} | Checkedin? : {guestresult[i].getCheckedIn()}" );
                                    Label temp = new Label(3, 8+i, guestsresultarr[i]);
                                    Button tempB = new Button(100, 8+i, "Edit" );
                                    tempcontainer.Add(temp);
                                    tempcontainer_B.Add(tempB);
                                }
                                List<Guest> guest = new List<Guest>();
                                for (int i = 0; i < tempcontainer.Count; i++)
                                {
                                    win.Add(tempcontainer[i]);
                                    win.Add(tempcontainer_B[i]);
                                    tempcontainer_B[i].Id = ustring.Make(i.ToString());
                                    
                                }
                                foreach (Button item in tempcontainer_B)
                                {
                                    item.Clicked += () => {
                                        guest.Add(repo.ViewGuest(guestresult[Int32.Parse(item.Id.ToString())].getId(), Globals.current_location));
                                        EditGuest(guest[0]);
                                    };
                                }
                            }
                            else
                            {
                            win.RemoveAll();
                            tempcontainer.Clear();
                            win.Add(GuestS, GuestS_t, Search);
                            List<Guest> guestresult = repo.GuestLookUp(GuestS_t.Text.ToString(), Globals.current_location);
                            ustring[] guestsresultarr = new ustring[guestresult.Count];
                                for (int i = 0; i < guestresult.Count; i++)
                                {
                                    guestsresultarr[i] = ustring.Make($"Name: {guestresult[i].getFirstName()} {guestresult[i].getLastName()} | Room: {guestresult[i].getRoom()} | Credits Remaining: {guestresult[i].getCredit()} | Checkedin? : {guestresult[i].getCheckedIn()}" );
                                    Label temp = new Label(3, 8+i, guestsresultarr[i]);
                                    Button tempB = new Button(100, 8+i, "Edit" );
                                    tempcontainer.Add(temp);
                                    tempcontainer_B.Add(tempB);
                                }
                                List<Guest> guest = new List<Guest>();
                                for (int i = 0; i < tempcontainer.Count; i++)
                                {
                                    win.Add(tempcontainer[i]);
                                    win.Add(tempcontainer_B[i]);
                                    tempcontainer_B[i].Id = ustring.Make(i.ToString());
                                    
                                }
                                foreach (Button item in tempcontainer_B)
                                {
                                    item.Clicked += () => {
                                        guest.Add(repo.ViewGuest(guestresult[Int32.Parse(item.Id.ToString())].getId(), Globals.current_location));
                                        EditGuest(guest[0]);
                                    };
                                }
                            }
                            GuestS_t.Text = "";
                        };
                        
                        win.Add(GuestS, GuestS_t, Search);
            }

            void ClearWindow()
            {
                    top.RemoveAll();
                    win.RemoveAll();
                    top.Add(win);
            }

            void Register_Complete()
            {
                ClearWindow();
                EmployeeScreen();
            MenuBar employee_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Register Guest", "", () => { if (true) RegisterGuestWin ();}),
                            new MenuItem ("_Loggout", "", () => { if (true) Loggout(); }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });

            MenuBar admin_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Register Guest", "", () => { if (true) RegisterGuestWin ();}),
                            new MenuItem ("_Employee Actions", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Loggout", "", () => { if (true) Loggout(); }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });
                if(Globals.admin == false)
                {
                    top.Add(employee_menu);
                }
                else
                {
                    top.Add(admin_menu);
                }
            }

            bool RegisterGuestWin()
            {
                ClearWindow();
                List<Room> rooms = repo.GetAllRooms(Globals.current_location);
                List<int> room_ids = new List<int>();

            ustring[] loc_rooms = new ustring[rooms.Count];
            for (int i = 0; i < rooms.Count; i++)
            {
                loc_rooms[i] = ustring.Make($"{rooms[i].getName()} | Vacancies: {rooms[i].getAmount()} |  Price: {rooms[i].getPrice()} | Description: {rooms[i].getDescription()}");
                room_ids.Add(rooms[i].getId());
            }
            MenuBar employee_menu_RG = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Return to Main", "", () => { if (true) Register_Complete();}),
                            new MenuItem ("_Logout", "", () => { if (true) Loggout(); }),
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
                repo.RegisterGuest(confirmation_number_t.Text.ToString(), first_name_t.Text.ToString(), last_name_t.Text.ToString(), room_t.Text.ToString(), Decimal.Parse(credit_t.Text.ToString()), Int32.Parse(durationofstay_t.Text.ToString()), Byte.Parse((checked_in_RG.SelectedItem).ToString()), Globals.current_location, room_ids[room_selection.SelectedItem]);
                Register_Complete();
            };
                win.Add(instructions, currLoc, first_name, first_name_t, last_name, last_name_t, room, room_t, credit, credit_t, confirmation_number, confirmation_number_t, durationofstay, durationofstay_t, checked_in, checked_in_RG, Submit_RegGuest, room_selection);
                top.Add(employee_menu_RG);
                return true;
            }

            void EditGuest(Guest guest)
            {
                ClearWindow();
            MenuBar employee_menu_RG = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Return to Main", "", () => { if (true) Register_Complete();}),
                            new MenuItem ("_Logout", "", () => { if (true) Loggout(); }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });
             /*

              - fix edit button on previous page
              - write unit tests
             */
                Label first_name_l = new Label(3, 3, "First Name: ");
                TextField first_name = new TextField(3, 4, 40, $"{guest.getFirstName()}");
                Label last_name_l = new Label(3, 5, "Last Name: ");
                TextField last_name = new TextField(3, 6, 40, $"{guest.getLastName()}");
                Label room_l = new Label(3, 7, "room #:");
                TextField room = new TextField(3, 8, 40, $"{guest.getRoom()}");
                Label credit_l = new Label(3, 9, "credit amount: ");
                TextField credit = new TextField(3, 10, 40, $"{guest.getCredit()}");
                Label confirmation_number = new Label(3, 12, $"{guest.getConfirmNum()}");
                Label durationofstay_l = new Label(3, 14, "Duration of Stay");
                TextField durationofstay = new TextField(3, 15, 40, $"{guest.getDurationOfStay()}");
                Button Submit = new Button(30, 30, "Submit");
            Submit.Clicked += () => {
                repo.EditGuest(guest.getId(), confirmation_number.Text.ToString(), first_name.Text.ToString(), last_name.Text.ToString(), room.Text.ToString(), Decimal.Parse(credit.Text.ToString()), Int32.Parse(durationofstay.Text.ToString()), Globals.current_location, guest.getRoom_Id());
                Register_Complete();
            };
            top.Add(employee_menu_RG);
            win.Add(first_name, last_name, room, credit, confirmation_number, durationofstay, Submit, first_name_l, last_name_l, durationofstay_l, credit_l, room_l);
            }
            
            void Loggout()
            {
                        MenuBar init_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; })
                        }),
                    });
            MenuBar employee_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Register Guest", "", () => { if (true) RegisterGuestWin ();}),
                            new MenuItem ("_Loggout", "", () => { if (true) Loggout(); }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });

            MenuBar admin_menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_Actions", new MenuItem [] {
                            new MenuItem ("_Register Guest", "", () => { if (RegisterGuestWin ()) ;}),
                            new MenuItem ("_Employee Actions", "", () => { if (Quit ()) top.Running = false; }),
                            new MenuItem ("_Loggout", "", () => { if (true) Loggout(); }),
                            new MenuItem ("_Quit", "", () => { if (Quit ()) top.Running = false; }),
                        }),
                    });
                ClearWindow();
                top.Add(init_menu);
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

            Globals.current_location = 0;
            Globals.admin = false;

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
                        EmployeeScreen();
                        top.Add(employee_menu);
                        Globals.current_location = login_rg.SelectedItem+1;
                        Globals.admin = false;
                    }
                    else
                    {
                        EmployeeScreen();
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
                        new Label (55, 2, "failed login, try again")
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
                new Label(3, 8, "Select your hotel location before login"),
                login_rg,
                okayB,
                cancelB
            );
            }
        

            

            Application.Run();
    }
}
}