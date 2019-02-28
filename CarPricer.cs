using System;


#region Instructions
/*
 * You are tasked with writing an algorithm that determines the value of a used car, 
 * given several factors.
 * 
 *    AGE:    Given the number of months of how old the car is, reduce its value one-half 
 *            (0.5) percent.
 *            After 10 years, it's value cannot be reduced further by age. This is not 
 *            cumulative.
 *            
 *    MILES:    For every 1,000 miles on the car, reduce its value by one-fifth of a
 *              percent (0.2). Do not consider remaining miles. After 150,000 miles, it's 
 *              value cannot be reduced further by miles.
 *            
 *    PREVIOUS OWNER:    If the car has had more than 2 previous owners, reduce its value 
 *                       by twenty-five (25) percent. If the car has had no previous  
 *                       owners, add ten (10) percent of the FINAL car value at the end.
 *                    
 *    COLLISION:        For every reported collision the car has been in, remove two (2) 
 *                      percent of it's value up to five (5) collisions.
 *                    
 * 
 *    Each factor should be off of the result of the previous value in the order of
 *        1. AGE
 *        2. MILES
 *        3. PREVIOUS OWNER
 *        4. COLLISION
 *        
 *    E.g., Start with the current value of the car, then adjust for age, take that  
 *    result then adjust for miles, then collision, and finally previous owner. 
 *    Note that if previous owner, had a positive effect, then it should be applied 
 *    AFTER step 4. If a negative effect, then BEFORE step 4.
 */
#endregion



namespace CarPricer
{
    public class Car
    {
        public decimal PurchaseValue { get; set; }
        public int AgeInMonths { get; set; }
        public int NumberOfMiles { get; set; }
        public int NumberOfPreviousOwners { get; set; }
        public int NumberOfCollisions { get; set; }
    }

    public class PriceDeterminator
    {
        public double currentCarValue;
        public bool isSingleOwner = false;
        public double initialCarValue;
        public double DetermineCarPrice(Car car)
        {           
            if (car == null)
            {
                throw new NullReferenceException("Car object cannot be null!");
            }
            if (car.PurchaseValue > 0)
            {
                currentCarValue = double.Parse(car.PurchaseValue.ToString());
                initialCarValue = currentCarValue;
            }
            //Step 1 
            currentCarValue -= GetAgeFactor(car.AgeInMonths);
            //Step 2 
            currentCarValue -= GetMilesFactor(car.NumberOfMiles);

            //Previous owner had a positive effect.
            if (isSingleOwner)
            {
                //Step 3
                currentCarValue -= GetCollisionFactor(car.NumberOfCollisions);
                //Step 4
                currentCarValue -= GetPreviousOwnerFactor(car.NumberOfPreviousOwners);
                //Apply positive effect
                currentCarValue += currentCarValue * 0.1;
            }

            //Previous owner had a negative effect, have to switch the order of operations.
            else
            {
                //Step 4
                currentCarValue -= GetPreviousOwnerFactor(car.NumberOfPreviousOwners);
                //Step 3
                currentCarValue -= GetCollisionFactor(car.NumberOfCollisions);
            }
            return currentCarValue;
        }

       
        private double GetAgeFactor(int months)
        {
            if (months / 12 > 10)
            {
                return 0;
            }
            else
            {
                return currentCarValue * 0.5;
            }
        }

        private double GetMilesFactor(int miles)
        {
            if (miles > 150000)
            {
                return 0;
            }
            else
            {
                return miles / 1000 * 0.2;
            }
        }

        private double GetPreviousOwnerFactor(int numOwners)
        {
            if (numOwners == 0)
            {
                isSingleOwner = true;
                return 0;
            }
            else if (numOwners > 2)
            {
                return currentCarValue * 0.25;
            }
            else
            {
                return 0;
            }
        }

        private double GetCollisionFactor (int collissions)
        {
            double result;
            if (collissions <= 5)
            {
                int totalPercentage = collissions * 2;
                result = totalPercentage / 100 * currentCarValue;                               
            }
            else
            {
                result = 0;
            }

            return result;
        }

    }



}
