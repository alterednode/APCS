public class App {
    public static void main(String[] args) {
        int size = 32;
        int lines = 5;
        for (int i = 1; i <= lines; i++ ){
            for (int slash = size/2; slash + 4 - 4 * i >= 1; slash-- ){
                System.out.print("/");
            }
            for (int ast = 1; ast <=  (i - 1) * 8; ast++ ){
                System.out.print("*");
            }

            for (int slash = size/2; slash + 4 - 4 * i >= 1; slash-- ){
                System.out.print("\\");
            }
            System.out.println();
        }
    }
}
