package Common;

import java.util.ArrayList;
import java.util.List;

public class WheelStyle {
    //室
    public static List<String> createSString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i < 10; i++) {
            wheelString.add(String.valueOf(i)+"室");
        }
        return wheelString;
    }
    //厅
    public static List<String> createTString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 0; i < 10; i++) {
            wheelString.add(String.valueOf(i)+"厅");
        }
        return wheelString;
    }
    //卫
    public static List<String> createWString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 0; i < 10; i++) {
            wheelString.add(String.valueOf(i)+"卫");
        }
        return wheelString;
    }
    //朝向
    public static List<String> createCXString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"东","南","西","北","南北","东西","东南","西南","东北","西北"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //层
    public static List<String> createCString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = -2; i < 100; i++) {
            wheelString.add( i + "层");
        }
        return wheelString;
    }
    //共几层
    public static List<String> createGJCString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i < 100; i++) {
            wheelString.add("共" + i + "层");
        }
        return wheelString;
    }
    //车位
    public static List<String> createCWString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"有车位","无车位"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //电梯
    public static List<String> createDTString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"有电梯","无电梯"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //看房时间
    public static List<String> createKFSJString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"随时看房","仅周末","仅工作日"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //租客性别
    public static List<String> createZKXBString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"男女不限","限女生","限男生"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //宜住人数
    public static List<String> createYZRSString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i <= 10; i++) {
            wheelString.add(i + "人");
        }
        return wheelString;
    }
    //年
    public static List<String> createYearString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"2018","2019"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString() + "年");
        }
        return wheelString;
    }
    //月
    public static List<String> createMonthString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i <= 12; i++) {
            wheelString.add(i + "月");
        }
        return wheelString;
    }
    //日
    public static List<String> createDayString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i <= 31; i++) {
            wheelString.add(i + "日");
        }
        return wheelString;
    }
    //卧室类型
    public static List<String> createWSLXString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"主卧","次卧","隔断"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //房屋类型
    public static List<String> createFWLXString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"普通住宅","公寓","别墅","平房","新里洋房","老公房","四合院"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //供暖类型
    public static List<String> createGNLXString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"集中供暖","自供暖","不供暖"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //产权年限
    public static List<String> createCQNXString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"70年产权","50年产权","40年产权"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //产权类型
    public static List<String> createCQLXString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"商品房","经济适用房","小产权房"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //装修情况
    public static List<String> createZXQKString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"毛坯","简单装修","中等装修","精装修","豪华装修"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //商铺类型
    public static List<String> createSPLXString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"商业街商铺","写字楼配套","社区底商","档口摊位","临街门面"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //押
    public static List<String> createYString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i < 10; i++) {
            wheelString.add("押" + String.valueOf(i));
        }
        return wheelString;
    }
    //付
    public static List<String> createFString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 0; i < 10; i++) {
            wheelString.add("付" + String.valueOf(i));
        }
        return wheelString;
    }
    //其他类型
    public static List<String> createQTLXString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"厂房","仓库","土地","车位"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //车辆颜色
    public static List<String> createCLYSString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"白","灰","银","红","蓝","黄","绿"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString());
        }
        return wheelString;
    }
    //上牌年份
    public static List<String> createSPNFString() {
        List<String> wheelString = new ArrayList<>();
        String[] array = new String[]{"2013","2014","2015","2016","2017","2018"};
        for (int i = 0; i < array.length; i++) {
            wheelString.add(array[i].toString() + "年");
        }
        return wheelString;
    }
    //过户次数
    public static List<String> createGHCSString() {
        List<String> wheelString = new ArrayList<>();
        for (int i = 1; i <= 10; i++) {
            wheelString.add(i + "次");
        }
        return wheelString;
    }
}