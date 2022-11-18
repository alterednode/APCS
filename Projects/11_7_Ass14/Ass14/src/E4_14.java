public class E4_14 {
    public static void main(String[] args) throws Exception {
        // computationally efficient
        System.out.println("+--+--+--+\n|  |  |  |\n+--+--+--+\n|  |  |  |\n+--+--+--+\n|  |  |  |\n+--+--+--+");
       
       System.out.println();

        // understandable
        String a = "+--+--+--+\n";
        String b = "|  |  |  |\n";
        System.out.println(a+b+a+b+a+b+a);
        
        // Slightly different

        for (int i = 0; i < 7; i++){
            if (i % 2==0){
                System.out.print(a);
            }else System.out.print(b);
        }

        System.out.println();

        // comb??

        String comb = "+--+--+--+\n|  |  |  |\n";
        String bottom = "+--+--+--+";
        for (int i = 1; i <= 3; i ++)
        System.out.print(comb);
        System.out.println(bottom);
    }
}
