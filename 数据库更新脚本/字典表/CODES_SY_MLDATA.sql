prompt Importing table codes_sy_ml...
set feedback off
set define off
insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (1, null, '房产', 1, null, 'DL', 'FC', null, null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2, null, '房屋租售', 1, 1, 'XL', 'FC', null, null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (3, null, '商业地产租售', 2, 1, 'XL', 'FC', null, null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (4, 19, '整租', 1, 2, null, 'FC', 'CZFS=1', '是', '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (5, 1902, '合租', 2, 2, null, 'FC', 'CZFS=2', null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (6, 328, '日租/短租', 3, 2, null, 'FC', null, null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (7, 21, '二手房', 4, 2, null, 'FC', null, '是', '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (8, null, '新房', 5, 2, null, 'FC', null, '是', '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (9, 20, '商铺', 1, 3, null, 'FC', null, null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (10, 289, '写字楼', 2, 3, null, 'FC', null, null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (11, 293, '厂房', 3, 3, null, 'FC', null, null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (12, 2931, '仓库', 4, 3, null, 'FC', null, null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (13, 2932, '土地', 5, 3, null, 'FC', null, null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (14, 2933, '车位', 6, 3, null, 'FC', null, null, '房产');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (16, null, '车辆', 2, null, 'DL', 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (17, null, '商用车', 2, 16, 'XL', 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (18, null, '二手车', 1, 16, 'XL', 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (19, null, '车辆周边', 3, 16, 'XL', 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (20, 68, '货车', 1, 17, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (21, 62, '工程车', 2, 17, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (38, 66, '自行车', 17, 18, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (39, 63, '三轮车', 18, 18, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (40, 61, '二手轿车', 13, 18, null, 'CL', null, '是', '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (41, 69, '客车', 14, 18, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (42, 65, '摩托车', 15, 18, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (43, 64, '电动车', 16, 18, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (47, 124, '租车', 1, 19, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (48, 125, '代驾', 2, 19, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (49, 119, '驾校', 3, 19, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (50, null, '宠物', 3, null, 'DL', 'CW', null, null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (51, 73, '狗狗', 1, 50, 'XL', 'CW', null, null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (52, 74, '猫猫', 2, 50, 'XL', 'CW', null, null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (53, 75, '花鸟鱼虫', 3, 50, 'XL', 'CW', null, null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (54, 80, '宠物服务', 4, 50, 'XL', 'CW', null, null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (56, 79, '宠物用品', 6, 50, 'XL', 'CW', null, null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (57, 78, '宠物公益', 7, 50, 'XL', 'CW', null, null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (58, 73, '金毛', 1, 51, null, 'CW', 'PZ=金毛', '是', '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (59, 73, '哈士奇', 2, 51, null, 'CW', 'PZ=哈士奇', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (60, 73, '阿拉斯加', 3, 51, null, 'CW', 'PZ=阿拉斯加', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (61, 73, '泰迪', 4, 51, null, 'CW', 'PZ=泰迪', '是', '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (62, 73, '斗牛犬', 5, 51, null, 'CW', 'PZ=斗牛犬', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (63, 73, '格力犬', 6, 51, null, 'CW', 'PZ=格力犬', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (64, 74, '蓝猫', 1, 52, null, 'CW', 'PZ=蓝猫', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (65, 74, '折耳猫', 2, 52, null, 'CW', 'PZ=折耳猫', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (66, 74, '加菲猫', 3, 52, null, 'CW', 'PZ=加菲猫', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (67, 74, '布偶猫', 4, 52, null, 'CW', 'PZ=布偶猫', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (68, 74, '短毛猫', 5, 52, null, 'CW', 'PZ=短毛猫', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (69, 74, '豹猫', 6, 52, null, 'CW', 'PZ=豹猫', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (70, 75, '观赏鱼', 1, 53, null, 'CW', 'LB=观赏鱼', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (71, 75, '玩赏鸟', 2, 53, null, 'CW', 'LB=玩赏鸟', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (72, 75, '奇石盆景', 3, 53, null, 'CW', 'LB=奇石盆景', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (73, 80, '配种', 1, 54, null, 'CW', 'LB=宠物配种', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (74, 80, '训练', 2, 54, null, 'CW', 'LB=宠物训练', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (75, 80, '托运', 3, 54, null, 'CW', 'LB=宠物托运', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (76, 80, '美容', 5, 54, null, 'CW', 'LB=宠物美容', '是', '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (77, 80, '寄养', 6, 54, null, 'CW', 'LB=宠物寄养', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (78, 80, '医院', 4, 54, null, 'CW', 'LB=宠物医院', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (79, 79, '狗用品', 1, 56, null, 'CW', 'LB=狗用品', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (80, 79, '猫用品', 2, 56, null, 'CW', 'LB=猫用品', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (81, 79, '其他用品', 3, 56, null, 'CW', 'LB=其他宠物用品', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (82, 78, '赠送', 1, 57, null, 'CW', 'LB=宠物赠送', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (83, 78, '寻宠启事', 3, 57, null, 'CW', 'LB=寻宠启事', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (84, 205, '招聘', 4, null, 'DL', 'ZP', 'ZWLB=招聘', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (85, 205, '福利专区', 1, 84, 'XL', 'ZP', 'ZWLB=福利专区', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (86, 205, '热招行业', 2, 84, 'XL', 'ZP', 'ZWLB=热招行业', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (87, 205, '热招职位', 3, 84, 'XL', 'ZP', 'ZWLB=热招职位', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (88, 205, '年底双薪', 1, 85, null, 'ZP', 'ZWLB=年底双薪', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (89, 205, '包吃', 2, 85, null, 'ZP', 'ZWLB=包吃', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (90, 205, '包住', 3, 85, null, 'ZP', 'ZWLB=包住', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (91, 205, '五险一金', 4, 85, null, 'ZP', 'ZWLB=五险一金', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (92, 205, '交通补助', 5, 85, null, 'ZP', 'ZWLB=交通补助', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (93, 205, '房补', 6, 85, null, 'ZP', 'ZWLB=房补', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (94, 205, '双休', 7, 85, null, 'ZP', 'ZWLB=双休', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (95, 205, '带薪年假', 8, 85, null, 'ZP', 'ZWLB=带薪年假', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (96, 205, '餐饮', 1, 86, null, 'ZP', 'HYLB=餐饮', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (97, 205, '家政保洁', 2, 86, null, 'ZP', 'HYLB=家政保洁', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (98, 205, '美容/美发', 3, 86, null, 'ZP', 'HYLB=美容/美发', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (99, 205, '酒店', 4, 86, null, 'ZP', 'HYLB=酒店', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (100, 205, '保健按摩', 5, 86, null, 'ZP', 'HYLB=保健按摩', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (101, 205, '运动健身', 6, 86, null, 'ZP', 'HYLB=运动健身', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (102, 205, '旅游', 7, 86, null, 'ZP', 'HYLB=旅游', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (103, 205, '行政/后勤', 8, 86, null, 'ZP', 'HYLB=人事/行政/后勤', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (104, 205, '销售', 1, 87, null, 'ZP', 'HYLB=销售', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (105, 205, '客服', 2, 87, null, 'ZP', 'ZWLB=客服', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (106, 205, '文员', 3, 87, null, 'ZP', 'ZWLB=文员', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (107, 205, '会计', 4, 87, null, 'ZP', 'ZWLB=会计', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (108, 205, '普工', 5, 87, null, 'ZP', 'ZWLB=普工', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (109, 205, '保安', 6, 87, null, 'ZP', 'ZWLB=保安', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (110, 205, '保姆', 7, 87, null, 'ZP', 'ZWLB=保姆', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (111, 205, '司机', 8, 87, null, 'ZP', 'ZWLB=司机', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (112, 205, '厨师', 9, 87, null, 'ZP', 'ZWLB=厨师', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (113, 205, '检验', 10, 87, null, 'ZP', 'ZWLB=检验', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (114, 205, '服务员', 11, 87, null, 'ZP', 'ZWLB=服务员', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (115, 205, '淘宝客服', 12, 87, null, 'ZP', 'ZWLB=淘宝客服', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (116, 205, '保洁', 13, 87, null, 'ZP', 'ZWLB=保洁', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (117, 205, '采购', 14, 87, null, 'ZP', 'ZWLB=采购', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (118, 205, '快递员', 15, 87, null, 'ZP', 'ZWLB=快递员', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (119, 205, '平面设计', 16, 87, null, 'ZP', 'ZWLB=平面设计', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (120, 205, '美发', 17, 87, null, 'ZP', 'ZWLB=美发', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (121, 205, '出纳', 18, 87, null, 'ZP', 'ZWLB=出纳', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (122, 205, '收银员', 19, 87, null, 'ZP', 'ZWLB=收银员', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (123, 205, '健身教练', 20, 87, null, 'ZP', 'ZWLB=健身教练', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (124, 205, '外贸', 21, 87, null, 'ZP', 'ZWLB=外贸', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (125, 205, '幼教', 22, 87, null, 'ZP', 'ZWLB=幼教', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (126, 205, '洗车工', 23, 87, null, 'ZP', 'ZWLB=洗车工', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (128, 205, '房产', 25, 87, null, 'ZP', 'ZWLB=房产', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (129, 205, '演员', 26, 87, null, 'ZP', 'ZWLB=演员', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (130, 205, '美容师', 27, 87, null, 'ZP', 'ZWLB=美容师', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (131, 205, '仓库管理', 28, 87, null, 'ZP', 'ZWLB=仓库管理', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (132, 205, '电工', 29, 87, null, 'ZP', 'ZWLB=电工', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (133, 205, '导游', 30, 87, null, 'ZP', 'ZWLB=导游', null, '招聘');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (134, 206, '兼职', 5, null, 'DL', 'JZ', null, null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (135, 206, '促销/导购', 1, 134, null, 'JZ', 'JZLB=促销/导购', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (136, 206, '网络营销', 2, 134, null, 'JZ', 'JZLB=网络营销', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (137, 206, '传单派发', 3, 134, null, 'JZ', 'JZLB=传单派发', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (138, 206, '礼仪/模特', 4, 134, null, 'JZ', 'JZLB=礼仪/模特', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (139, 206, '问卷调查', 5, 134, null, 'JZ', 'JZLB=问卷调查', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (140, 206, '生活配送员', 6, 134, null, 'JZ', 'JZLB=生活配送员', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (141, 206, '游戏代练', 7, 134, null, 'JZ', 'JZLB=游戏代练', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (142, 206, '家教', 8, 134, null, 'JZ', 'JZLB=家教', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (143, 206, '钟点工', 9, 134, null, 'JZ', 'JZLB=钟点工', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (144, 206, '会计', 10, 134, null, 'JZ', 'JZLB=会计', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (145, 206, '平面设计', 11, 134, null, 'JZ', 'JZLB=平面设计', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (146, 206, '艺术老师', 12, 134, null, 'JZ', 'JZLB=艺术老师', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (147, 206, '化妆师', 13, 134, null, 'JZ', 'JZLB=化妆师', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (148, 206, '网站建设', 14, 134, null, 'JZ', 'JZLB=网站建设', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (149, 206, '导游', 15, 134, null, 'JZ', 'JZLB=导游', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (150, 206, '汽车陪练', 16, 134, null, 'JZ', 'JZLB=汽车陪练', null, '兼职');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (151, null, '教育培训', 6, null, 'DL', 'PX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (152, 259, '中小学辅导班', 1, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (153, 262, '中小学一对一', 2, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (154, 261, '家教机构', 3, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (155, 260, '家教个人', 4, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (156, 263, '语言培训机构', 5, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (157, 264, '语言培训教师', 6, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (158, 267, '艺术培训机构', 7, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (160, 275, '艺术培训教师', 9, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (161, 265, '职业技能培训', 10, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (162, 268, '体育培训', 11, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (163, 276, '体育教练', 12, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (164, null, '生活服务', 7, null, 'DL', 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (165, null, '家政服务', 1, 164, 'XL', 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (166, null, '维修服务', 2, 164, 'XL', 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (167, null, '装修建材', 3, 164, 'XL', 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (169, null, '婚庆摄影', 5, 164, 'XL', 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (170, null, '旅游酒店', 6, 164, 'XL', 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (171, null, '休闲服务', 7, 164, 'XL', 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (172, null, '丽人', 8, 164, 'XL', 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (173, 102, '搬家', 1, 165, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (174, 103, '月嫂保姆', 2, 165, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (175, 104, '保洁清洗', 3, 165, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (177, 107, '管道疏通', 4, 165, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (178, 108, '生活配送', 5, 165, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (179, 106, '开锁修锁', 7, 166, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (180, 111, '白事服务', 6, 165, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (181, 112, '家电维修', 1, 166, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (182, 113, '电脑维修', 2, 166, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (183, 114, '房屋维修', 3, 166, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (184, 115, '家具维修', 4, 166, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (186, 116, '手机维修', 5, 166, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (187, 117, '数码维修', 6, 166, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (188, 253, '家装服务', 1, 167, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (189, 254, '工装服务', 2, 167, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (190, 255, '房屋改造', 3, 167, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (191, 256, '建材', 4, 167, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (192, 257, '家具', 5, 167, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (193, 258, '家纺家饰', 6, 167, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (200, 208, '婚庆公司', 1, 169, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (201, 331, '婚车租赁', 2, 169, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (202, 332, '婚宴酒店', 3, 169, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (203, 333, '彩妆造型', 4, 169, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (204, 334, '婚庆用品', 5, 169, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (205, 335, '司仪', 6, 169, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (206, 336, '婚礼跟拍', 7, 169, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (207, 337, '婚纱礼服', 8, 169, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (209, 339, '婚纱摄影', 10, 169, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (210, 246, '旅行社', 1, 170, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (211, 247, '国内游', 2, 170, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (212, 248, '周边游', 3, 170, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (213, 249, '出境游', 4, 170, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (214, 250, '酒店/住宿', 5, 170, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (215, null, '农家乐', 1, 213, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (216, null, '烧烤', 2, 213, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (217, null, '度假村', 3, 213, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (218, null, '温泉', 4, 213, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (219, null, '采摘', 5, 213, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (220, null, '漂流', 6, 213, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (221, null, '订房', 1, 214, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (222, null, '自驾游', 2, 214, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (223, null, '旅行社', 3, 214, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (224, null, '出境', 4, 214, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (225, null, '签证', 5, 214, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (226, null, '跟团', 6, 214, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (227, 172, '运动健身', 1, 171, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (228, 173, '酒吧', 2, 171, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (230, 215, '美体瘦身', 1, 172, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (231, 216, '美容护肤', 2, 172, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (232, 217, 'SPA', 3, 172, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (233, 218, '舞蹈', 4, 172, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (234, 330, '瑜伽', 5, 172, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (235, null, '商务服务', 8, null, 'DL', 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (236, null, '商务服务', 1, 235, 'XL', 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (237, null, '招商加盟', 2, 235, 'XL', 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (239, null, '批发采购', 4, 235, 'DL', 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (240, null, '农林牧副渔', 5, 235, 'XL', 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (241, 301, '工商注册', 1, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (242, 302, '商标专利', 2, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (243, 303, '法律咨询', 3, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (244, 304, '财务会计/评估', 4, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (245, 305, '保险', 5, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (246, 306, '投资担保', 6, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (247, 307, '印刷包装', 7, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (248, 308, '喷绘招牌', 8, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (249, 309, '设计策划', 9, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (250, 310, '广告传媒', 10, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (251, 311, '展会服务', 11, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (252, 312, '礼品定制', 12, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (253, 313, '制卡', 13, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (254, 314, '翻译/速记', 14, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (255, 315, '网络布线/维护', 15, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (256, 316, '网站建设/推广', 16, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (257, 317, '咨询服务', 17, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (258, 319, '快递', 18, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (259, 320, '货运物流', 19, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (260, 321, '货运专线', 20, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (261, 322, '办公设备维修', 21, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (262, 323, '租赁', 22, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (263, 159, '餐饮', 0, 237, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (264, 160, '服装鞋包', 1, 237, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (265, 162, '机械', 2, 237, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (266, 161, '建材', 3, 237, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (267, 163, '美容保健', 4, 237, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (268, 164, '礼品商品', 5, 237, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (269, 165, '家居环保', 6, 237, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (270, 166, '教育培训', 7, 237, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (271, 167, '汽车服务', 8, 237, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (275, 224, '食品', 1, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (276, 225, '礼品', 2, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (277, 226, '服饰鞋帽', 3, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (278, 281, '畜禽养殖', 4, 240, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (279, 278, '园林花卉', 1, 240, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (280, 280, '动植物种苗', 3, 240, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (281, 279, '农作物', 2, 240, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (282, 282, '水产', 5, 240, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (283, 283, '肥料/农药', 6, 240, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (284, 284, '饲料/兽药', 7, 240, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (285, 285, '农机具/设备', 8, 240, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (286, 286, '农产品加工', 9, 240, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (291, null, '二手市集', 10, null, 'DL', 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (292, null, '手机数码', 1, 291, 'XL', 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (293, null, '生活百货', 2, 291, 'XL', 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (295, 186, '二手手机', 1, 292, null, 'ES', null, '是', '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (296, 187, '笔记本电脑', 3, 292, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (297, 190, '台式电脑', 4, 292, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (299, 189, '数码产品', 5, 292, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (301, 188, '平板电脑', 2, 292, null, 'ES', null, '是', '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (302, 195, '母婴用品', 5, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (303, 191, '家用家电', 1, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (304, 192, '二手家具', 2, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (305, 193, '家居日用', 3, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (306, 194, '办公设备', 4, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (307, 199, '文体户外', 7, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (309, 198, '工艺收藏', 8, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (310, 83, '消费卡券', 8, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (311, 85, '演出门票', 9, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (312, 86, '游园景点', 10, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (313, 84, '其他卡券', 11, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (314, 196, '服饰鞋帽', 13, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (315, 200, '图书音像', 14, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (316, 202, '二手设备', 15, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (321, 78, '领养', 2, 57, null, 'CW', 'LB=宠物领养', null, '宠物');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (322, 195, '儿童用品', 5, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (323, 195, '儿童玩具', 6, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (324, 197, '美容保健', 14, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (325, 201, '网游虚拟', 15, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (326, 204, '成人用品', 16, 293, null, 'ES', null, null, '二手');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (327, 168, '网络服务', 9, 237, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (328, 169, '农业', 10, 237, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (329, 170, '特色', 11, 237, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (330, 171, '生活服务', 12, 237, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (331, 295, '母婴儿童', 13, 237, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (332, 227, '箱包饰品', 4, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (333, 228, '手机数码', 5, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (334, 229, '母婴玩具', 6, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (335, 230, '户外运动', 7, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (336, 231, '化妆品', 8, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (337, 232, '安防设备', 9, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (338, 233, '纺织布料', 10, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (339, 234, '商超设备', 11, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (340, 235, '化学品', 12, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (341, 236, '电工电料', 13, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (342, 237, '电子元器件', 14, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (343, 238, '仪表仪器', 15, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (344, 239, '灯具照明', 16, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (345, 240, '原材料', 17, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (346, 241, '包装', 18, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (348, 243, '图书', 20, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (349, 244, '卡券', 21, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (350, 245, '机械加工', 22, 239, null, 'PFCG', null, null, '批发采购');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (351, 266, '学历教育', 13, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (352, 269, 'IT培训', 14, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (353, 270, '设计培训', 15, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (354, 271, '管理培训', 16, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (355, 272, '婴幼儿教育', 17, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (356, 273, '留学', 18, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (357, 274, '移民', 19, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (358, 277, '拼班拼课', 20, 151, null, 'JYPX', null, null, '教育培训');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (491, 120, '陪练', 4, 19, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (492, 121, '维修/保养', 5, 19, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (493, 122, '过户/验车', 6, 19, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (494, 123, '美容/装饰', 7, 19, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (495, 126, '改装/防护', 8, 19, null, 'CL', null, null, '车辆');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2141, 251, '机票', 6, 170, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2281, 175, '户外', 3, 171, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2282, 176, '洗浴温泉', 4, 171, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2283, 177, '足疗按摩', 5, 171, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2284, 178, '台球厅', 6, 171, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2285, 179, '棋牌桌游', 7, 171, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2286, 180, 'DIY手工坊', 8, 171, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2287, 182, '轰趴馆', 9, 171, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2288, 174, 'KTV', 3, 171, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2341, 219, '美发护发', 6, 172, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2342, 220, '美甲', 7, 172, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2343, 221, '纹身', 8, 172, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2344, 222, '口腔护理', 9, 172, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2345, 223, '体检', 10, 172, null, 'SHFW', null, null, '生活服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2621, 324, '代办签证/签注', 23, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2622, 325, '建筑维修', 24, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2623, 326, '机械设备维修', 25, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2624, 209, '摄影/摄像', 26, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2625, 210, '礼仪庆典', 27, 236, null, 'SWFW', null, null, '商务服务');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME)
values (2626, 110, '起名/风水/算命', 28, 236, null, 'SWFW', null, null, '商务服务');

prompt Done.
