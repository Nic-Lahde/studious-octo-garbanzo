using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            int runCounter = 1;
            static void NewQuest(int runCounter)
            {
                // Create a few challenges for our Adventurer's quest
                // The "Challenge" Constructor takes three arguments
                //   the text of the challenge
                //   a correct answer
                //   a number of awesome points to gain or lose depending on the success of the challenge
                Challenge chameleon = new Challenge(@"Why do chamleons change color?
    1) To blend in with their environment
    2) To look cool
    3) To communicate with other chameleons
    4) To show how hot or cold they are
",
                    3, 40
                );
                Challenge mario = new Challenge(@"The US Mario 2 for the NES is a reskin of what Japanese game?
    1) Terminator: Reckoning
    2) Doki-Doki Panic
    3) Trouble House: Traps are many!
    4) Sailor Moon
",
                    2, 30
                );

                Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
                Challenge theAnswer = new Challenge(
                    "What's the answer to life, the universe and everything?", 42, 25);
                Challenge whatSecond = new Challenge(
                    "What is the current second?", DateTime.Now.Second, 50);

                int randomNumber = new Random().Next() % 10;
                Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

                Challenge favoriteBeatle = new Challenge(
                    @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                    4, 20
                );

                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                Prize prize = new Prize("You won an unusually heavy egg!");
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                // Make a new "Adventurer" object using the "Adventurer" class
                Console.WriteLine("Name your adventurer");
                string player = Console.ReadLine();
                Robe newRobe = new Robe()
                {
                    Colors = new List<string> { "red", "blue", "green" },
                    Length = 400
                };
                Hat newHat = new Hat(8);
                Adventurer theAdventurer = new Adventurer(player, newRobe, newHat);
                theAdventurer.Awesomeness += (runCounter * 10) - 10;
                Console.WriteLine(theAdventurer.GetDescription());

                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>() { chameleon, mario, twoPlusTwo, theAnswer, whatSecond, guessRandom, favoriteBeatle };

                List<int> challengesIndex = new List<int>();
                Random random = new Random();

                while (challengesIndex.Count < 5)
                {
                    int challengeIndex = GetRandomInt(random, 0, challenges.Count - 1);
                    if (!challengesIndex.Contains(challengeIndex))
                    {
                        challengesIndex.Add(challengeIndex);
                    }
                }

                // Loop through all the challenges and subject the Adventurer to them
                foreach (int challengeIndex in challengesIndex)
                {
                    challenges[challengeIndex].RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }
                prize.ShowPrize(theAdventurer);
                Console.WriteLine("Would you like to play again? Y/N");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "y" || choice.ToLower() == "yes")
                {
                    runCounter++;
                    NewQuest(runCounter);
                }
                else if (choice.ToLower() == "n" || choice.ToLower() == "no")
                {
                    Console.WriteLine("Well fine then!");
                }
                else
                {
                    Console.WriteLine("You don't follow insctructions very well.");
                }
            }
            NewQuest(runCounter);

        }
        static int GetRandomInt(Random random, int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }


}