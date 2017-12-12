prompt Importing table codes_sy_ml...
set feedback off
set define off
insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (1, null, '房产', 1, null, 'DL', 'FC', null, null, '房产', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (2, null, '车辆', 2, null, 'DL', 'CL', null, null, '车辆', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (3, null, '宠物', 3, null, 'DL', 'CW', null, null, '宠物', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (4, null, '批发采购', 4, null, 'DL', 'PFCG', null, null, '批发采购', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (5, null, '招聘', 5, null, 'DL', 'ZP', 'ZWLB=招聘', null, '招聘', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (6, null, '兼职', 6, null, 'DL', 'JZ', null, null, '兼职', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (7, null, '教育培训', 7, null, 'DL', 'JYPX', null, null, '教育培训', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (8, null, '生活服务', 8, null, 'DL', 'SHFW', null, null, '生活服务', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (9, null, '商务服务', 9, null, 'DL', 'SWFW', null, null, '商务服务', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (10, null, '二手市集', 10, null, 'DL', 'ES', null, null, '二手', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (11, null, '房屋租售', 1, 1, 'XL', 'FC', null, null, '房产', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (12, null, '商业地产租售', 2, 1, 'XL', 'FC', null, null, '房产', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (13, null, '二手车', 1, 2, 'XL', 'CL', null, null, '车辆', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (14, null, '商用车', 2, 2, 'XL', 'CL', null, null, '车辆', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (15, null, '车辆周边', 3, 2, 'XL', 'CL', null, null, '车辆', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (16, 31, '狗狗', 1, 3, 'XL', 'CW', null, null, '宠物', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (17, 32, '猫猫', 2, 3, 'XL', 'CW', null, null, '宠物', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (18, 33, '花鸟鱼虫', 3, 3, 'XL', 'CW', null, null, '宠物', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (19, 34, '宠物服务', 4, 3, 'XL', 'CW', null, null, '宠物', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (22, null, '福利专区', 1, 5, 'XL', 'ZP', 'ZWLB=福利专区', null, '招聘', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (23, null, '热招行业', 2, 5, 'XL', 'ZP', 'ZWLB=热招行业', null, '招聘', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (24, null, '热招职位', 3, 5, 'XL', 'ZP', 'ZWLB=热招职位', null, '招聘', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (25, null, '家政服务', 1, 8, 'XL', 'SHFW', null, null, '生活服务', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (26, null, '维修服务', 2, 8, 'XL', 'SHFW', null, null, '生活服务', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (27, null, '装修建材', 3, 1, 'XL', 'FC', null, null, '房产', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (28, null, '婚庆摄影', 4, 8, 'XL', 'SHFW', null, null, '生活服务', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (29, null, '旅游酒店', 5, 8, 'XL', 'SHFW', null, null, '生活服务', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (30, null, '休闲服务', 6, 8, 'XL', 'SHFW', null, null, '生活服务', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (32, null, '商务服务', 1, 9, 'XL', 'SWFW', null, null, '商务服务', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (33, null, '招商加盟', 2, null, 'DL', 'ZSJM', null, null, '招商加盟', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (35, null, '手机数码', 1, 10, 'XL', 'ES', null, null, '二手', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (36, null, '生活百货', 2, 10, 'XL', 'ES', null, null, '二手', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (37, 68, '食品', 1, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_SP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (38, 69, '礼品', 2, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_LP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (39, 70, '服饰鞋帽', 3, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_FSXM');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (40, 71, '箱包饰品', 4, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_XBSP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (41, 72, '手机数码', 5, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_SJSM');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (42, 73, '母婴玩具', 6, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_MYWJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (43, 74, '户外运动', 7, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_HWYD');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (44, 75, '化妆品', 8, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_HZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (45, 76, '安防设备', 9, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_AFSB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (46, 77, '纺织布料', 10, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_FZBL');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (47, 78, '商超设备', 11, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_SCSB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (48, 79, '化学品', 12, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_HXP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (49, 80, '电工电料', 13, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_DGDL');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (50, 81, '电子元器件', 14, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_DZYQJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (51, 82, '仪表仪器', 15, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_YBYQ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (52, 83, '灯具照明', 16, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_DJZM');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (53, 84, '原材料', 17, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_YCL');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (54, 85, '包装', 18, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_BZ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (55, 86, '图书', 19, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_TS');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (56, 87, '卡券', 20, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_KQ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (57, 88, '机械加工', 21, 4, null, 'PFCG', null, null, '批发采购', '/PFCGCX/PFCGCX_JXJG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (58, 90, '促销/导购', 1, 6, null, 'JZ', 'JZLB=促销/导购', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (59, 90, '网络营销', 2, 6, null, 'JZ', 'JZLB=网络营销', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (60, 90, '传单派发', 3, 6, null, 'JZ', 'JZLB=传单派发', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (61, 90, '礼仪/模特', 4, 6, null, 'JZ', 'JZLB=礼仪/模特', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (62, 90, '问卷调查', 5, 6, null, 'JZ', 'JZLB=问卷调查', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (63, 90, '生活配送员', 6, 6, null, 'JZ', 'JZLB=生活配送员', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (64, 90, '游戏代练', 7, 6, null, 'JZ', 'JZLB=游戏代练', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (65, 90, '家教', 8, 6, null, 'JZ', 'JZLB=家教', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (66, 90, '钟点工', 9, 6, null, 'JZ', 'JZLB=钟点工', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (67, 90, '会计', 10, 6, null, 'JZ', 'JZLB=会计', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (68, 90, '平面设计', 11, 6, null, 'JZ', 'JZLB=平面设计', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (69, 90, '艺术老师', 12, 6, null, 'JZ', 'JZLB=艺术老师', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (70, 90, '化妆师', 13, 6, null, 'JZ', 'JZLB=化妆师', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (71, 90, '网站建设', 14, 6, null, 'JZ', 'JZLB=网站建设', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (72, 90, '导游', 15, 6, null, 'JZ', 'JZLB=导游', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (73, 90, '汽车陪练', 16, 6, null, 'JZ', 'JZLB=汽车陪练', null, '兼职', '/QZZPCX/QZZPCX_JZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (74, 104, '辅导班', 1, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_ZXXFDB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (75, 105, '一对一', 2, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_ZXXYDY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (76, 106, '家教机构', 3, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_JJJG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (77, 107, '家教个人', 4, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_JJGR');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (78, 108, '语言培训', 5, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_YYPXJG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (80, 110, '艺术培训', 7, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_YSPXJG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (82, 112, '职业培训', 9, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_ZYJNPX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (83, 113, '体育培训', 10, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_TYPX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (84, 114, '体育教练', 11, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_TYJL');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (85, 115, '学历教育', 12, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_XLJY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (86, 116, 'IT培训', 13, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_ITPX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (87, 117, '设计培训', 14, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_SJPX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (88, 118, '管理培训', 15, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_GLPX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (89, 119, '婴幼儿教育', 17, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_YYEJY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (90, 120, '留学', 18, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_LX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (91, 121, '移民', 19, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_YM');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (92, 122, '拼班拼课', 16, 7, null, 'JYPX', null, null, '教育培训', '/JYPXCX/JYPXCX_PBPK');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (93, 13, '整租', 1, 11, null, 'FC', null, '是', '房产', '/FCCX/FCCX_ZZF');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (94, 14, '合租', 2, 11, null, 'FC', null, null, '房产', '/FCCX/FCCX_HZF');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (95, 15, '日租/短租', 3, 11, null, 'FC', null, null, '房产', '/FCCX/FCCX_DZF');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (96, 16, '二手房', 4, 11, null, 'FC', null, '是', '房产', '/FCCX/FCCX_ESF');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (97, 16, '新房', 5, 11, null, 'FC', null, '是', '房产', null);

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (98, 17, '商铺', 1, 12, null, 'FC', null, null, '房产', '/FCCX/FCCX_SP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (99, 18, '写字楼', 2, 12, null, 'FC', null, null, '房产', '/FCCX/FCCX_XZL');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (100, 19, '厂房', 3, 12, null, 'FC', null, null, '房产', '/FCCX/FCCX_CF');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (101, 20, '仓库', 4, 12, null, 'FC', null, null, '房产', '/FCCX/FCCX_CK');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (102, 21, '土地', 5, 12, null, 'FC', null, null, '房产', '/FCCX/FCCX_TD');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (103, 22, '车位', 6, 12, null, 'FC', null, null, '房产', '/FCCX/FCCX_CW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (104, 185, '二手轿车', 1, 13, null, 'CL', null, '是', '车辆', '/CLCX/CLCX_JC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (105, 192, '客车', 2, 13, null, 'CL', null, null, '车辆', '/CLCX/CLCX_KC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (106, 187, '摩托车', 3, 13, null, 'CL', null, null, '车辆', '/CLCX/CLCX_MTC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (107, 186, '电动车', 4, 13, null, 'CL', null, null, '车辆', '/CLCX/CLCX_DDC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (108, 188, '自行车', 5, 13, null, 'CL', null, null, '车辆', '/CLCX/CLCX_ZXC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (109, 189, '三轮车', 6, 13, null, 'CL', null, null, '车辆', '/CLCX/CLCX_SLC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (110, 190, '货车', 1, 14, null, 'CL', null, null, '车辆', '/CLCX/CLCX_HC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (111, 191, '工程车', 2, 14, null, 'CL', null, null, '车辆', '/CLCX/CLCX_GCC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (112, 193, '租车', 1, 15, null, 'CL', null, null, '车辆', '/CLCX/CLCX_ZC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (113, 194, '代驾', 2, 15, null, 'CL', null, null, '车辆', '/CLCX/CLCX_DJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (114, 195, '驾校', 3, 15, null, 'CL', null, null, '车辆', '/CLCX/CLCX_JX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (115, 196, '陪练', 4, 15, null, 'CL', null, null, '车辆', '/CLCX/CLCX_PL');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (116, 197, '维修/保养', 5, 15, null, 'CL', null, null, '车辆', '/CLCX/CLCX_QCWXBY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (117, 198, '过户/验车', 6, 15, null, 'CL', null, null, '车辆', '/CLCX/CLCX_GHSPNJYC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (118, 199, '美容/装饰', 7, 15, null, 'CL', null, null, '车辆', '/CLCX/CLCX_QCMRZS');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (119, 200, '改装/防护', 8, 15, null, 'CL', null, null, '车辆', '/CLCX/CLCX_QCGZFH');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (120, 31, '金毛', 1, 16, null, 'CW', 'PZ=金毛', '是', '宠物', '/CWCX/CWCX_CWG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (121, 31, '哈士奇', 2, 16, null, 'CW', 'PZ=哈士奇', null, '宠物', '/CWCX/CWCX_CWG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (122, 31, '阿拉斯加', 3, 16, null, 'CW', 'PZ=阿拉斯加', null, '宠物', '/CWCX/CWCX_CWG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (126, 32, '蓝猫', 1, 17, null, 'CW', 'PZ=蓝猫', null, '宠物', '/CWCX/CWCX_CWM');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (127, 32, '折耳猫', 2, 17, null, 'CW', 'PZ=折耳猫', null, '宠物', '/CWCX/CWCX_CWM');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (128, 32, '加菲猫', 3, 17, null, 'CW', 'PZ=加菲猫', null, '宠物', '/CWCX/CWCX_CWM');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (132, 33, '观赏鱼', 1, 18, null, 'CW', 'LB=观赏鱼', null, '宠物', '/CWCX/CWCX_HNYC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (133, 33, '玩赏鸟', 2, 18, null, 'CW', 'LB=玩赏鸟', null, '宠物', '/CWCX/CWCX_HNYC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (134, 33, '奇石盆景', 3, 18, null, 'CW', 'LB=奇石盆景', null, '宠物', '/CWCX/CWCX_HNYC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (135, 34, '配种', 1, 19, null, 'CW', 'LB=宠物配种', null, '宠物', '/CWCX/CWCX_CWFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (136, 34, '训练', 2, 19, null, 'CW', 'LB=宠物训练', null, '宠物', '/CWCX/CWCX_CWFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (137, 34, '托运', 3, 19, null, 'CW', 'LB=宠物托运', null, '宠物', '/CWCX/CWCX_CWFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (138, 34, '医院', 4, 19, null, 'CW', 'LB=宠物医院', null, '宠物', '/CWCX/CWCX_CWFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (139, 34, '美容', 5, 19, null, 'CW', 'LB=宠物美容', '是', '宠物', '/CWCX/CWCX_CWFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (140, 34, '寄养', 6, 19, null, 'CW', 'LB=宠物寄养', null, '宠物', '/CWCX/CWCX_CWFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (147, 89, '年底双薪', 1, 22, null, 'ZP', 'ZWLB=年底双薪', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (148, 89, '包吃', 8, 22, null, 'ZP', 'ZWLB=包吃', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (149, 89, '包住', 7, 22, null, 'ZP', 'ZWLB=包住', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (150, 89, '五险一金', 3, 22, null, 'ZP', 'ZWLB=五险一金', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (151, 89, '交通补助', 4, 22, null, 'ZP', 'ZWLB=交通补助', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (152, 89, '房补', 5, 22, null, 'ZP', 'ZWLB=房补', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (153, 89, '双休', 6, 22, null, 'ZP', 'ZWLB=双休', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (154, 89, '带薪年假', 2, 22, null, 'ZP', 'ZWLB=带薪年假', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (155, 89, '餐饮', 1, 23, null, 'ZP', 'HYLB=餐饮', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (156, 89, '销售', 2, 23, null, 'ZP', 'HYLB=销售', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (158, 89, '美容/美发', 4, 23, null, 'ZP', 'HYLB=美容/美发', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (159, 89, '酒店', 5, 23, null, 'ZP', 'HYLB=酒店', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (160, 89, '保健按摩', 6, 23, null, 'ZP', 'HYLB=保健按摩', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (161, 89, '运动健身', 7, 23, null, 'ZP', 'HYLB=运动健身', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (163, 89, '客服', 1, 24, null, 'ZP', 'ZWLB=客服', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (164, 89, '文员', 2, 24, null, 'ZP', 'ZWLB=文员', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (165, 89, '会计', 3, 24, null, 'ZP', 'ZWLB=会计', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (166, 89, '普工', 4, 24, null, 'ZP', 'ZWLB=普工', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (167, 89, '保安', 5, 24, null, 'ZP', 'ZWLB=保安', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (168, 89, '旅游', 6, 24, null, 'ZP', 'HYLB=旅游', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (169, 89, '保姆', 7, 24, null, 'ZP', 'ZWLB=保姆', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (170, 89, '司机', 8, 24, null, 'ZP', 'ZWLB=司机', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (171, 89, '厨师', 9, 24, null, 'ZP', 'ZWLB=厨师', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (172, 89, '检验', 10, 24, null, 'ZP', 'ZWLB=检验', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (173, 89, '服务员', 11, 24, null, 'ZP', 'ZWLB=服务员', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (174, 89, '淘宝客服', 12, 24, null, 'ZP', 'ZWLB=淘宝客服', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (175, 89, '保洁', 13, 24, null, 'ZP', 'ZWLB=保洁', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (176, 89, '采购', 14, 24, null, 'ZP', 'ZWLB=采购', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (177, 89, '快递员', 15, 24, null, 'ZP', 'ZWLB=快递员', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (178, 89, '平面设计', 16, 24, null, 'ZP', 'ZWLB=平面设计', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (179, 89, '美发', 17, 24, null, 'ZP', 'ZWLB=美发', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (180, 89, '出纳', 18, 24, null, 'ZP', 'ZWLB=出纳', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (181, 89, '收银员', 19, 24, null, 'ZP', 'ZWLB=收银员', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (182, 89, '健身教练', 20, 24, null, 'ZP', 'ZWLB=健身教练', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (183, 89, '外贸', 21, 24, null, 'ZP', 'ZWLB=外贸', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (184, 89, '幼教', 22, 24, null, 'ZP', 'ZWLB=幼教', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (185, 89, '洗车工', 23, 24, null, 'ZP', 'ZWLB=洗车工', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (186, 89, '房产', 25, 24, null, 'ZP', 'ZWLB=房产', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (187, 89, '演员', 26, 24, null, 'ZP', 'ZWLB=演员', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (188, 89, '美容师', 27, 24, null, 'ZP', 'ZWLB=美容师', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (189, 89, '仓库管理', 28, 24, null, 'ZP', 'ZWLB=仓库管理', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (190, 89, '电工', 29, 24, null, 'ZP', 'ZWLB=电工', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (191, 89, '导游', 30, 24, null, 'ZP', 'ZWLB=导游', null, '招聘', '/QZZPCX/QZZPCX_QZZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (192, 172, '搬家', 1, 25, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_BJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (193, 173, '保姆月嫂', 2, 25, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_BMYS');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (194, 174, '保洁清洗', 3, 25, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_BJQX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (195, 175, '管道疏通', 4, 25, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_GDST');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (196, 176, '生活配送', 5, 25, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_SHPS');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (197, 177, '白事服务', 6, 25, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_BSFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (198, 178, '家电维修', 1, 26, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_JDWX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (199, 179, '电脑维修', 2, 26, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_DNWX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (200, 180, '房屋维修', 3, 26, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_FWWX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (201, 181, '家具维修', 4, 26, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_JJWX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (202, 182, '手机维修', 5, 26, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_SJWX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (203, 184, '数码维修', 6, 26, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_SMWX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (204, 183, '开锁修锁', 7, 26, null, 'SHFW', null, null, '生活服务', '/SHFWCX/SHFWCX_KSXS');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (205, 130, '家装服务', 1, 27, null, 'SHFW', null, null, '生活服务', '/ZXJCCX/ZXJCCX_JZFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (206, 131, '工装服务', 2, 27, null, 'SHFW', null, null, '生活服务', '/ZXJCCX/ZXJCCX_GZFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (207, 132, '房屋改造', 3, 27, null, 'SHFW', null, null, '生活服务', '/ZXJCCX/ZXJCCX_FWGZ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (208, 133, '建材', 4, 27, null, 'SHFW', null, null, '生活服务', '/ZXJCCX/ZXJCCX_JC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (209, 134, '家具', 5, 27, null, 'SHFW', null, null, '生活服务', '/ZXJCCX/ZXJCCX_JJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (210, 135, '家纺家饰', 6, 27, null, 'SHFW', null, null, '生活服务', '/ZXJCCX/ZXJCCX_JFJS');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (211, 136, '婚庆公司', 1, 28, null, 'SHFW', null, null, '生活服务', '/HQSYCX/HQSYCX_HQGS');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (212, 137, '婚车租赁', 2, 28, null, 'SHFW', null, null, '生活服务', '/HQSYCX/HQSYCX_HCZL');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (213, 138, '婚宴酒店', 3, 28, null, 'SHFW', null, null, '生活服务', '/HQSYCX/HQSYCX_HYJD');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (214, 139, '彩妆造型', 4, 28, null, 'SHFW', null, null, '生活服务', '/HQSYCX/HQSYCX_CZZX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (215, 140, '婚庆用品', 5, 28, null, 'SHFW', null, null, '生活服务', '/HQSYCX/HQSYCX_HQYP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (216, 141, '司仪', 6, 28, null, 'SHFW', null, null, '生活服务', '/HQSYCX/HQSYCX_SY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (217, 142, '婚礼跟拍', 7, 28, null, 'SHFW', null, null, '生活服务', '/HQSYCX/HQSYCX_HLGP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (218, 143, '婚纱礼服', 8, 28, null, 'SHFW', null, null, '生活服务', '/HQSYCX/HQSYCX_HSLF');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (219, 144, '婚纱摄影', 9, 28, null, 'SHFW', null, null, '生活服务', '/HQSYCX/HQSYCX_HLGP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (220, 123, '旅行社', 1, 29, null, 'SHFW', null, null, '生活服务', '/LYJDCX/LYJDCX_LXS');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (221, 124, '国内游', 2, 29, null, 'SHFW', null, null, '生活服务', '/LYJDCX/LYJDCX_GNY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (222, 125, '周边游', 3, 29, null, 'SHFW', null, null, '生活服务', '/LYJDCX/LYJDCX_ZBY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (223, 126, '出境游', 4, 29, null, 'SHFW', null, null, '生活服务', '/LYJDCX/LYJDCX_CJY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (224, 127, '酒店/住宿', 5, 29, null, 'SHFW', null, null, '生活服务', '/LYJDCX/LYJDCX_JDZSYD');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (225, 128, '机票', 6, 29, null, 'SHFW', null, null, '生活服务', '/LYJDCX/LYJDCX_HW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (226, 44, '运动健身', 1, 30, null, 'SHFW', null, null, '生活服务', '/XXYLCX/XXYLCX_YDJS');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (227, 45, '酒吧', 2, 30, null, 'SHFW', null, null, '生活服务', '/XXYLCX/XXYLCX_YDJB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (228, 46, 'KTV', 3, 30, null, 'SHFW', null, null, '生活服务', '/XXYLCX/XXYLCX_KTV');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (229, 47, '户外', 4, 30, null, 'SHFW', null, null, '生活服务', '/XXYLCX/XXYLCX_HW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (230, 48, '洗浴温泉', 5, 30, null, 'SHFW', null, null, '生活服务', '/XXYLCX/XXYLCX_XYWQ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (231, 49, '足疗按摩', 6, 30, null, 'SHFW', null, null, '生活服务', '/XXYLCX/XXYLCX_ZLAM');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (232, 50, '台球厅', 7, 30, null, 'SHFW', null, null, '生活服务', '/XXYLCX/XXYLCX_TQT');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (233, 51, '棋牌桌游', 8, 30, null, 'SHFW', null, null, '生活服务', '/XXYLCX/XXYLCX_QPZY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (234, 52, 'DIY手工坊', 9, 30, null, 'SHFW', null, null, '生活服务', '/XXYLCX/XXYLCX_DIYSGF');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (235, 53, '轰趴馆', 10, 30, null, 'SHFW', null, null, '生活服务', '/XXYLCX/XXYLCX_HPG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (246, 211, '工商注册', 1, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_GSZC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (247, 212, '商标专利', 2, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_SBZL');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (248, 213, '法律咨询', 3, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_FLZX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (249, 214, '财务会计', 4, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_CWKJPG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (250, 215, '保险', 5, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_BX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (251, 216, '投资担保', 6, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_TZDB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (252, 217, '印刷包装', 7, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_YSBZ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (253, 218, '喷绘招牌', 8, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_PHZP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (254, 219, '设计策划', 9, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_SJCH');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (255, 220, '广告传媒', 10, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_GGCM');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (256, 221, '展会服务', 11, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_ZHFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (257, 222, '礼品定制', 12, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_LPDZ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (258, 223, '制卡', 13, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_ZK');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (259, 234, '翻译/速记', 14, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_FYSJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (260, 227, '网络布线', 15, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_WLBXWH');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (261, 228, '网站建设', 16, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_WZJSTG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (262, 235, '咨询服务', 17, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_ZXFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (263, 214, '快递', 18, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_KD');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (264, 215, '货运物流', 19, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_HYWL');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (265, 216, '货运专线', 20, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_HYZX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (266, 229, '办公维修', 21, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_BGSBWX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (267, 213, '租赁', 22, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_ZL');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (268, 224, '代办签证', 23, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_DBQZQZ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (269, 230, '建筑维修', 24, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_JZWX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (270, 231, '机械维修', 25, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_JXSBWX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (271, 225, '摄影摄像', 26, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_SYSX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (272, 226, '礼仪庆典', 27, 32, null, 'SWFW', null, null, '商务服务', '/SWFWCX/SWFWCX_LYQD');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (274, 54, '餐饮', 1, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_CY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (275, 55, '服装鞋包', 2, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_FZXB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (276, 57, '机械', 3, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_JX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (277, 56, '建材', 4, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_JC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (278, 58, '美容保健', 5, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_MRBJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (279, 59, '礼品商品', 6, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_LPSP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (280, 60, '家居环保', 7, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_JJHB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (281, 61, '教育培训', 8, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_JYPX');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (282, 62, '汽车服务', 9, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_QCFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (283, 63, '网络服务', 9, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_WLFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (284, 64, '农业', 10, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_NY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (285, 65, '特色', 11, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_TS');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (286, 66, '生活服务', 12, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_SHFW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (287, 67, '母婴儿童', 13, 33, null, 'SWFW', null, null, '招商加盟', '/ZSJMCX/ZSJMCX_MYET');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (288, 145, '园林花卉', 1, 34, null, 'SWFW', null, null, '商务服务', '/NLMFYCX/NLMFYCX_YLHH');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (289, 146, '农作物', 2, 34, null, 'SWFW', null, null, '商务服务', '/NLMFYCX/NLMFYCX_NZW');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (290, 147, '动植物种苗', 3, 34, null, 'SWFW', null, null, '商务服务', '/NLMFYCX/NLMFYCX_DZWZM');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (291, 148, '畜禽养殖', 4, 34, null, 'SWFW', null, null, '商务服务', '/NLMFYCX/NLMFYCX_QCYZ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (292, 149, '水产', 5, 34, null, 'SWFW', null, null, '商务服务', '/NLMFYCX/NLMFYCX_SC');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (293, 150, '肥料/农药', 6, 34, null, 'SWFW', null, null, '商务服务', '/NLMFYCX/NLMFYCX_FLNY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (294, 151, '饲料/兽药', 7, 34, null, 'SWFW', null, null, '商务服务', '/NLMFYCX/NLMFYCX_SLSY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (295, 152, '农机具/设备', 8, 34, null, 'SWFW', null, null, '商务服务', '/NLMFYCX/NLMFYCX_NJJSB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (296, 153, '农产品加工', 9, 34, null, 'SWFW', null, null, '商务服务', '/NLMFYCX/NLMFYCX_NCPJG');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (297, 154, '二手手机', 1, 35, null, 'ES', null, '是', '二手', '/ESCX/ESCX_SJSM_ESSJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (298, 156, '平板电脑', 2, 35, null, 'ES', null, '是', '二手', '/ESCX/ESCX_SJSM_PBDN');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (299, 155, '笔记本电脑', 3, 35, null, 'ES', null, null, '二手', '/ESCX/ESCX_SJSM_BJBDN');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (300, 158, '台式电脑', 4, 35, null, 'ES', null, null, '二手', '/ESCX/ESCX_SJSM_TSJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (301, 157, '数码产品', 5, 35, null, 'ES', null, null, '二手', '/ESCX/ESCX_SJSM_SMCP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (302, 159, '家用家电', 1, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_JDJJBG_ESJD');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (303, 160, '二手家具', 2, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_JDJJBG_ESJJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (304, 161, '家居日用', 3, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_JDJJBG_JJRY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (305, 162, '办公设备', 4, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_JDJJBG_BGSB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (306, 163, '母婴用品', 5, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_MYFZMR_MYETYPWJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (307, 163, '儿童用品', 6, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_MYFZMR_MYETYPWJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (308, 163, '儿童玩具', 7, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_MYFZMR_MYETYPWJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (309, 167, '文体户外', 8, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_WHYL_WTHWYQ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (310, 166, '工艺收藏', 9, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_WHYL_YSPSCP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (311, 39, '消费卡券', 10, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_PWKQ_XFKGWK');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (312, 37, '演出门票', 11, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_PWKQ_YCMP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (313, 38, '游园景点', 12, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_PWKQ_YLYJDP');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (314, 40, '其他卡券', 13, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_PWKQ_QTKQ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (315, 164, '服饰鞋帽', 14, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_MYFZMR_FSXMXB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (316, 168, '图书音像', 15, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_WHYL_TSYXRJ');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (317, 165, '美容保健', 16, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_MYFZMR_MRBY');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (318, 170, '二手设备', 17, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_QTES_ESSB');

insert into codes_sy_ml (ID, LBID, LBNAME, LBORDER, PARENTID, TYPE, TYPENAME, CONDITION, ISHOT, TYPESHOWNAME, LBURL)
values (320, 171, '成人用品', 19, 36, null, 'ES', null, null, '二手', '/ESCX/ESCX_QTES_CRYP');

prompt Done.
