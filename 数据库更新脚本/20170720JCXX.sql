-- Create table
create table JCXX
(
  jcxxid VARCHAR2(50) not null,
  yhid   VARCHAR2(50),
  cjsj   DATE,
  zxgxsj DATE,
  llcs   NUMBER(10),
  lxr    VARCHAR2(50),
  lxdh   VARCHAR2(20),
  lxdz   VARCHAR2(200),
  qq     VARCHAR2(20),
  bt     VARCHAR2(100),
  dh     VARCHAR2(100),
  status NUMBER(2)
)
tablespace XIAOZHEN
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  );
-- Add comments to the table 
comment on table JCXX
  is '基础信息';
-- Add comments to the columns 
comment on column JCXX.jcxxid
  is '基础信息ID';
comment on column JCXX.yhid
  is '用户ID';
comment on column JCXX.cjsj
  is '创建时间';
comment on column JCXX.zxgxsj
  is '最新更新时间';
comment on column JCXX.llcs
  is '浏览次数';
comment on column JCXX.lxr
  is '联系人';
comment on column JCXX.lxdh
  is '联系电话';
comment on column JCXX.lxdz
  is '联系地址';
comment on column JCXX.qq
  is 'QQ';
comment on column JCXX.bt
  is '标题';
comment on column JCXX.dh
  is '导航';
comment on column JCXX.status
  is '当前状态（0:删除,1:显示,2:隐藏,3:待审核）';
-- Create/Recreate primary, unique and foreign key constraints 
alter table JCXX
  add constraint PK_JCXX primary key (JCXXID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table JCXX
  add constraint FK_JCXX_REFERENCE_YHJBXX foreign key (YHID)
  references YHJBXX (YHID);
