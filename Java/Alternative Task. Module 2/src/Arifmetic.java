public class Arifmetic {
    public static void main(String[] args) {

        char[] operations = {'+', '-', '*', '/', ' '};
        int[] numbers = {9, 8, 7, 6, 5, 4, 3, 2};

        for (char op : operations) {
            for(char op1 : operations) {
                for(char op2 : operations) {
                    for(char op3 : operations) {
                        for(char op4 : operations) {
                            for(char op5 : operations) {
                                for(char op6 : operations) {
                                    String numbTemp = ("9" + op + "8" + op1 + "7" + op2 + "6" + op3 + "5" + op4 + "4" + op5 + "3" + op6 +
                                            "2").replace(" ","");
                                    System.out.println(numbTemp);
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}