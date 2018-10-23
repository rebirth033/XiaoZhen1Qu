package FBXX.FC;

import java.util.ArrayList;
import java.util.List;

public class WheelStyle {

    public static List<String> createSString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i < 10; i++) {
            wheelString.add(String.valueOf(i)+"室");
        }
        return wheelString;
    }
    public static List<String> createTString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 0; i < 10; i++) {
            wheelString.add(String.valueOf(i)+"厅");
        }
        return wheelString;
    }
    public static List<String> createWString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 0; i < 10; i++) {
            wheelString.add(String.valueOf(i)+"卫");
        }
        return wheelString;
    }
    public static List<String> createCXString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"东","南","西","北","南北","东西","东南","西南","东北","西北"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    public static List<String> createCString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = -2; i < 100; i++) {
            wheelString.add( i + "层");
        }
        return wheelString;
    }
    public static List<String> createGJCString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i < 100; i++) {
            wheelString.add("共" + i + "层");
        }
        return wheelString;
    }
}