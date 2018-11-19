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
    public static List<String> createCWString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"有车位","无车位"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    public static List<String> createDTString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"有电梯","无电梯"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    public static List<String> createKFSJString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"随时看房","仅周末","仅工作日"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    public static List<String> createYZRSString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i <= 10; i++) {
            wheelString.add(i + "人");
        }
        return wheelString;
    }
    public static List<String> createYearString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"2018","2019"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString() + "年");
        }
        return wheelString;
    }
    public static List<String> createMonthString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i <= 12; i++) {
            wheelString.add(i + "月");
        }
        return wheelString;
    }
    public static List<String> createDayString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i <= 31; i++) {
            wheelString.add(i + "日");
        }
        return wheelString;
    }
}