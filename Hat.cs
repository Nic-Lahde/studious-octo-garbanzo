namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; }
        public string ShininessDescription { get; }

        public Hat(int shiny)
        {
            string description = "";
            ShininessLevel = shiny;
            if (shiny <= 1)
            {
                description = "dull";
            }
            else if (shiny >= 2 && shiny <= 5)
            {
                description = "noticeable";
            }
            else if (shiny >= 6 && shiny <= 9)
            {
                description = "bright";
            }
            else if (shiny > 9)
            {
                description = "blinding";
            }
            ShininessDescription = description;
        }
    }


}