using MOGYM.Models;

namespace MOGYM.Helpers
{
    public static class UserUtility
    {
        public static string DetermineUserRole(UserModel user)
        {
            if (user is AdminModel)
            {
                return "Admin";
            }
            else if (user is TrainerModel)
            {
                return "Trainer";
            }
            else if (user is TraineeModel)
            {
                return "Trainee";
            }

            return "User";
        }

        public static double CalculateBMI(int height, int weight)
        {
            if (height == 0 || weight == 0)
                return 0;

            double heightInMeters = height / 100.0;

            // Calculate BMI
            double bmi = Math.Round( weight / (heightInMeters * heightInMeters), 2 );

            return bmi;
        }
    }
}
