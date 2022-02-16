namespace MyFirstApi.Controllers.models
{
    public class User
    {

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty; //Guid.NewGuid().ToString();

        public int Age { get; set; } = 0;


        /*public User(string Name, string Surname, int Age)
        {

            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;

        }*/


        public Dictionary<string, string> toMap()
        {

            return new Dictionary<string, string>() {

                { "name" , this.Name },
                { "surname", this.Surname },
                { "age" , this.Age.ToString() },
                { "userId" , this.Id }

            };

        }



        public bool isValid()
        {

            if (this.Name != string.Empty && this.Surname!=string.Empty && this.Id != string.Empty && this.Age > 0)
            {
                return true;
            }

            return false;

        }


    }
}
