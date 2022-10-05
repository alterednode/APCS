public class Christmas {
    public static void main(String[] args) throws Exception {
        OnTheNthDay("first");
        Gift0();
        OnTheNthDay("second");
        Gift2();
        OnTheNthDay("third");
        Gift3();
        OnTheNthDay("fourth");
        Gift4();
        OnTheNthDay("fifth");
        Gift5();
        OnTheNthDay("sixth");
        Gift6();
        OnTheNthDay("seventh");
        Gift7();
        OnTheNthDay("eighth");
        Gift8();
        OnTheNthDay("ninth");
        Gift9();
        OnTheNthDay("tenth");
        Gift10();
        OnTheNthDay("eleventh");
        Gift11();
        OnTheNthDay("twelth");
        Gift12();
    }
    public static void OnTheNthDay(String whatDay){
        System.out.println("On the " + whatDay + " day of Christmas, my true love sent to me,");
    }

    public static void Gift0(){
        System.out.println("A partridge in a pear tree!\n");
    }
    public static void Gift1(){
        System.out.println("and a partridge in a pear tree!\n");
    }
    public static void Gift2(){
        System.out.println("Two turtle doves,");
        Gift1();
    }
    public static void Gift3(){
        System.out.println("Three french hens,");
        Gift2();
    }
    public static void Gift4(){
        System.out.println("Four calling birds,");
        Gift3();
    }
    public static void Gift5(){
        System.out.println("Five golden rings!!!");
        Gift4();
    }
    public static void Gift6(){
        System.out.println("Six geese a-laying,");
        Gift5();
    }
    public static void Gift7(){
        System.out.println("Seven swans a-swimming,");
        Gift6();
    }
    public static void Gift8(){
        System.out.println("Eight maids a-milking");
        Gift7();
    }
    public static void Gift9(){
        System.out.println("Nine ladies dancing");
        Gift8();
    }
    public static void Gift10(){
        System.out.println("Ten lords a-leaping,");
        Gift9();
    }
    public static void Gift11(){
        System.out.println("Eleven pipers piping,");
        Gift10();
    }
    public static void Gift12(){
        System.out.println("Twelve drummers drumming,");
        Gift11();
    }




}
