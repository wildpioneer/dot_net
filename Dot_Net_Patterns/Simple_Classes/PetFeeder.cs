namespace Simple_Classes;

public static class PetFeeder
{
    public static void FeedPet<TP, TF>(TP pet, TF food)
        where TP : PetAnimal
        where TF : IpetFood
    {
        pet.Feed(food);
    }
}