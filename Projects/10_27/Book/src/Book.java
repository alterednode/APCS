public class Book {
    public static int size;
    public static void main(String[] args) throws Exception {
        for (int i = 1; i < 39; i++){
            size = i;
            repeatThis("\n", 3);
System.out.println(i);
            repeatThis("\n", 3);
        repeatThis(" ", size+1);
        horizLine();
        System.out.println();
        upperSection();
        horizLine();
        repeatThis("/", size);
        System.out.println();
        LowerSection();
        horizLine();
        
        }
    }

    public static void horizLine(){
        System.out.print("+");
        repeatThis("-", 3*size);
        System.out.print("+");
    }

    public static void upperSection(){
        for (int i = 0; i < size; i++){

            repeatThis(" ", size-i);
            
            System.out.print("/");
            
            //weird spacing wtf
            if(i == size-1){
                repeatThis("_", 1);
            }else{
                repeatThis(" ", 1);
            }
            
            repeatThis("   ", size - (i + 1));
            repeatThis("__/", (i+1));
            repeatThis("/", i);

            //System.out.print("   "+i);
            System.out.println();
        }
    }

    public static void LowerSection(){
        String bookTitle = "Building Java Programs";

        for(int i = 0; i < size/2;i++){
            System.out.print("|");
            repeatThis(" ", (3*size - bookTitle.length())/2);
            System.out.print(bookTitle);
            if(size%2==1){
            System.out.print(" ");}
            repeatThis(" ", (3*size - bookTitle.length())/2);
            System.out.print("|");
            repeatThis("/", size-2*i);

            System.out.println();
        }

    }



    public static void repeatThis(String str, int number) {
        for (int i = 0; i < number; i++)
          System.out.print(str);
      }
}
