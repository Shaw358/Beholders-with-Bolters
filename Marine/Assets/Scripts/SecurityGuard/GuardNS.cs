namespace Guard
{
    enum GuardState
    {
        Patrolling, //walling around
        Alerted, //Noticed the player and calls security
        Responding //Reacts to the player and tries to kill him
    }
}