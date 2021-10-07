using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZooftVisit.Services
{
    public class DBFireBase
    {
        FirebaseClient client;

        public DBFireBase() {
            client = new FirebaseClient("https://zooft-10490-default-rtdb.firebaseio.com/");
        }
    }
}
