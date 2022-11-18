import java.util.Scanner;

public class _26 {
    public static void main(String[] args) throws Exception {
        
        Scanner in = new Scanner(System.in);
        System.out.println("enter the thing");
        String first = in.next();
        String mid = in.next();
        String last = in.next();
        System.out.println(first + " "+ mid + " "+ last); 
        in.close();
    }
}
