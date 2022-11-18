public class _25 {
    public static void main(String[] args) throws Exception {
        String str = "Harry";
        int n = str.length();
        String mystery = str.substring(0,1) + str.substring(n-1,n);
        
        System.out.println("It prints the first and last character of " + str + "\nIt could be done without the last n in the scond substring method\n\n" + mystery);
    }
}
