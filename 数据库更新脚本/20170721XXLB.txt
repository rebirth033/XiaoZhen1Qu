-- Create table
create table XXLB
(
  lbid     NUMBER(8) not null,
  lblx     VARCHAR2(100),
  lbname   VARCHAR2(100),
  lborder  NUMBER(8),
  parentid NUMBER(8),
  fbym     VARCHAR2(20),
  fbtable  VARCHAR2(50)
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
comment on table XXLB
  is '信息类别';
-- Add comments to the columns 
comment on column XXLB.lbid
  is '类别ID';
comment on column XXLB.lblx
  is '类别类型';
comment on column XXLB.lbname
  is '类别名称';
comment on column XXLB.lborder
  is '类别级别';
comment on column XXLB.parentid
  is '父级ID';
comment on column XXLB.fbym
  is '发布页面';
comment on column XXLB.fbtable
  is '类别对应数据表';
-- Create/Recreate primary, unique and foreign key constraints 
alter table XXLB
  add constraint PK_XXLB primary key (LBID)
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
