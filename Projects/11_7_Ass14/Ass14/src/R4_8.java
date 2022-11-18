public class R4_8 {
    public static void main(String[] args) throws Exception {
       
       // my answers
        String a =("10");
        String b = ("e");
        String c = ("llo");
        String d = ("HelloWorld");
        String e = ("WorldHello");

        String s = "Hello";
        String t = "World";

        String ComputerA = (s.length()+t.length()+"");
        String ComputerB = s.substring(1, 2);
        String ComputerC = s.substring(s.length()/2,s.length());
        String ComputerD = s + t;
        String ComputerE = t + s;

        
        System.out.println("\nA)\n\nMy answer : " + a + "\nComputer's: " + ComputerA);
        System.out.println("\nB)\n\nMy answer : " + b + "\nComputer's: " + ComputerB);
        System.out.println("\nC)\n\nMy answer : " + c + "\nComputer's: " + ComputerC);
        System.out.println("\nD)\n\nMy answer : " + d + "\nComputer's: " + ComputerD);
        System.out.println("\nE)\n\nMy answer : " + e + "\nComputer's: " + ComputerE);
        System.out.println();
    }
}
