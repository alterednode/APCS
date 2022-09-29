public class App {                                              
    public static void main(String[] args) {      
        System.out.println("\"Never Gonna Give You Up\"\n");
        System.out.println("We're no strangers to love");
        System.out.println("You know the rules and so do I");
        String s = "A full commitment's what I'm thinking of";
        System.out.println(s);
        System.out.println("You wouldn't get this from any other guy\n");
        String s2 = "I just wanna tell you how I'm feeling";
        System.out.println(s2);
        System.out.println("Gotta make you understand");
        System.out.print("\n");
        chorus();
        verse2();
        chorus();
        chorus();
    }
    /*
    Errors Found in above section:
    Missing "
    Improper Capitalization
    Missing chourus() (x2)
    changed some print (s) to println (s)
    
    
    
    */ 

    public static void chorus() {
        System.out.println("Never gonna give you up");
        System.out.println("Never gonna let you down");
        System.out.println("Never gonna run around and desert you");
        System.out.println("Never gonna make you cry");
        System.out.println("Never gonna say goodbye");
        System.out.println("Never gonna tell a lie and hurt you\n");
    }//fixed indentation

    public static void verse2()
    {
        System.out.print("We've known each other for so long\nYour heart\'s been aching, but\nYou\'re too shy to say it\nInside, we both know what\'s been going on\nWe know the game and we\'re gonna play it\n\n");
        //missing excape characters
        //extra spaces
    }
}