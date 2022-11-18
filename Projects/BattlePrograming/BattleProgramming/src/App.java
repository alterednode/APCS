import java.util.Random;
import java.util.Scanner;
public class App {
    static Scanner input = new Scanner(System.in);
    static int lvl ;
    static int atk ;
    static int def ;
    static int base;
    static int stab;
    static int hp ;
    public static void main(String[] args) throws Exception {
        

        
        String pokeName = battleStart();
        damage(pokeName);
        statsTable(pokeName);
        input.close();
    }

    public static String battleStart(){
        println("Another trainer is issuing a challenge!");
        println("Zebstrika appeared.");
        print("Which pokemon do you choose? ");
        String pokeName = input.nextLine();
        println("You choose " + pokeName + "!");
        println("It's a Pokemon battle between " + pokeName + " and Zebstrika!  Go!");
        return pokeName;
    }

    public static void damage(String name){
        println("Zebstrika used Thunderbolt!");
        println("Trainer, what are your "+name+"'s stats?");
        print("Level: ");
        lvl = input.nextInt(); //40
        print("Attack: ");
        atk = input.nextInt(); //110
        print("Defense: ");
        def = input.nextInt(); //80
        print("Base: ");
        base = input.nextInt(); //50
        print("STAB: ");
        stab = input.nextInt();//50
        print("HP: ");
        hp = input.nextInt(); //90

        //int avgDamage=0;
        //int count=0;
        //for (int i = 0; i < 2000000;i++){
        double modifier = .5*( 0.7 + (1-.7) * new Random().nextDouble());

        int damage =(int) Math.round(((2*lvl+10)/250+atk/def*base+2)*modifier) ;
        int hpAfterDamage = hp - (damage); 
        println("Arcanine sustained "+ damage + " points damage.");
        println("HP, after damage, are now " + hpAfterDamage);
       // avgDamage += damage; count = i+1;
        //}
        //System.out.println("\n\n\n\n" + avgDamage/count);

        //return hpAfterDamage;

    }

    public static void statsTable(String name){
        println("Name: \t" + name);
        println("Level:\t" + lvl);
        println("---------------------------");
        println("HP    \t"+hp);
        println("ATTACK\t"+atk);
        println("DEFENSE\t"+def);
        println("BASE   \t"+base);
        println("STAB   \t"+stab);
        println("---------------------------");
        println("Moves Learned: Suffer Through, Die Mentally, Hate Pokemon, BrainF***");

    }
    
    public static void println(String thing){
        System.out.println(thing);
    }
    public static void print(String thing){
        System.out.print(thing);
    }
}
