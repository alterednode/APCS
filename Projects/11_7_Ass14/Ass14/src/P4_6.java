import java.util.Scanner;

public class P4_6 {
    public static void main(String[] args) throws Exception {
        Scanner in = new Scanner(System.in);
        boolean phoneNumberGot=false;
        String rawNumber="";

        System.out.println("Give me your phone number");
        while (!phoneNumberGot){
            rawNumber = in.next();
            //input validation with length and regex to see if it is all made of numbers 0-9
            if (rawNumber.length()==10 &&rawNumber.matches("-?\\d+(\\.\\d+)?")){
                phoneNumberGot=true;
            }else System.out.println("I dont recognise \"" + rawNumber + "\" as a phone number,\ntry again:");
        }


        String areaCode = rawNumber.substring(0, 3);
        String midThree = rawNumber.substring(3,6);
        String lastFour = rawNumber.substring(6);

        System.out.println("("+areaCode+") "+midThree+"-"+lastFour);




        in.close();
    }
    
}
