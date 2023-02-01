public class App {
    public static void main(String[] args) throws Exception {
        System.out.println("distance from bal-man: "+distance(29, 16, 34, 8));//bal-man
        System.out.println("distance from los-falls: "+distance(6, 19, 22, 7));//los-falls
        System.out.println("distance from bad-pony: "+distance(25, 24, 16, 14));//bad-pony
        System.out.println("one way trip distance from bal-man-falls: "+trip(29, 16, 34, 8, 22,7 ));// bal - man - falls
        System.out.println("round trip distance from bal-man-falls: "+totalTrip(29, 16, 34, 8, 22,7 ));//bal - man - falls
        System.out.println("round trip distance from bal-man-falls-pony: "+totalTrip(29, 16, 34, 8, 22,7,16,14));//bal - man - falls - pony
    }

    public static double roadTrip (double dia){
        return Math.PI *dia; // mult diameter by pi
    }

    public static double distance(int x1, int y1,int x2,int y2){
        // convert to a double before taking the squeare root
        //  distance = | √ ((x2-x1)^2+(y2-y1)^2) |
        double distance = (Math.sqrt((double)(Math.pow((x2-y1), 2) + Math.pow((y2-y1), 2))));
        return distance;
    }

    public static double trip(int x1,int y1,int x2,int y2,int x3,int y3){
         // dist between first two + dist between second two
        return(distance(x1, y1, x2, y2)+distance(x2, y2, x3, y3));
    }

    public static double totalTrip(int x1, int y1, int x2, int y2, int x3, int y3){
        /*
        Add the distance bewteen each point and its following point, as well as dist last-first
        */
        return (distance(x1, y1, x2, y2)+distance(x2, y2, x3, y3)+distance(x1, y1, x3, y3));
    }

    public static double totalTrip(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4){
        /*
        Add the distance bewteen each point and its following point, as well as dist last-first
        */
        return (distance(x1, y1, x2, y2)+distance(x2, y2, x3, y3)+distance(x3, y3, x4, y4)+distance(x1, y1, x4, y4));
    }
    


}
