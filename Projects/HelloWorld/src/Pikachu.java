public class Pikachu {
    public static void main(String[] args) throws Exception {
    first();
    third();
    second();
    third();
      
    
    }
    public static void first(){
        System.out.println("Inside first method.");
    }
    public static void second(){
        System.out.println("Inside second method.");
        first();
    }
    public static void third(){
        first();
        second();    
        System.out.println("Inside third method.");
        
        
    }
}
