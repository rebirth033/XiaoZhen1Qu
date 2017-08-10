-- Create table
create table YHZHXX
(
  yhzhxxid VARCHAR2(50) not null,
  xjzje    NUMBER(12,2),
  kyje     NUMBER(12,2),
  djzje    NUMBER(12,2),
  yhid     VARCHAR2(50)
)
tablespace USERS
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
comment on table YHZHXX
  is '用户账户信息';
-- Add comments to the columns 
comment on column YHZHXX.yhzhxxid
  is '主键';
comment on column YHZHXX.xjzje
  is '现金总金额';
comment on column YHZHXX.kyje
  is '可用金额';
comment on column YHZHXX.djzje
  is '冻结中金额';
comment on column YHZHXX.yhid
  is '用户ID';
-- Create/Recreate primary, unique and foreign key constraints 
alter table YHZHXX
  add primary key (YHZHXXID)
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
