public class App {
    public static final int size = 4; 
    public static void main(String[] args) throws Exception {
        needle();
        muffin();
        underside();
        needle();
        elevator();
        muffin();
        
    }
    public static void needle(){
        for (int i = 0; i < size; i++){
            for (int j = 0; j < (size * 3);j++){
                System.out.print(" ");
            }
        System.out.println("||");
        }
    }

    public static void muffin(){
        for (int i = 0; i < size; i++){

            for (int j = 0; j < (size - (i + 1)) * 3; j++){
                System.out.print(" ");
            }


            System.out.print("__/");
            for (int j = 0; j < (i); j++)
            System.out.print(":::");
            System.out.print("||");
            for (int j = 0; j < (i); j++)
            System.out.print(":::");
            System.out.println("\\__");
        }
        System.out.print("|");
        for (int i = 0; i < size * 6; i++)
        System.out.print("\"");
        System.out.println("|");
    }
    public static void elevator(){
        for (int i =0; i < size * 4; i++){
            for (int j = 0; j < 2 * size + 1; j++){
                System.out.print(" ");
            }
            //TODO: make first and last thing of size n (0 and n) be |, else be %
            for(int j = 0; j < 2 * size ; j++){
               // if ()
            }
        }
    }
    public static void underside(){
        for (int i = 0; i < size; i++){
            for (int j = 0; j < i; j++){
                System.out.print("  ");
            }
            System.out.print("\\_");
            
            for (int j = 0; j < 2 * size + (size-1) - 2 * i ;j++){
                System.out.print("/\\");
            }

            System.out.println("_/");
        }
    }
}
