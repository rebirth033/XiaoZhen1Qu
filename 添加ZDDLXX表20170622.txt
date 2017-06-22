-- Create table
create table ZDDLXX
(
  zddlid    VARCHAR2(50) not null,
  yhm       VARCHAR2(100),
  sessionid VARCHAR2(100)
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
comment on table ZDDLXX
  is '自动登录信息';
-- Add comments to the columns 
comment on column ZDDLXX.zddlid
  is '主键';
comment on column ZDDLXX.yhm
  is '用户名';
comment on column ZDDLXX.sessionid
  is 'SESSIONID';
-- Create/Recreate primary, unique and foreign key constraints 
alter table ZDDLXX
  add primary key (ZDDLID)
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
