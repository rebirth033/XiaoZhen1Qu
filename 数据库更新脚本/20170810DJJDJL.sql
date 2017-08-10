-- Create table
create table DJJDJL
(
  djjdjlid VARCHAR2(50) not null,
  cjsj     DATE,
  je       NUMBER(10,2),
  lx       VARCHAR2(10),
  bz       VARCHAR2(100),
  yhzhxxid VARCHAR2(50)
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
comment on table DJJDJL
  is '用户账户_冻结解冻记录';
-- Add comments to the columns 
comment on column DJJDJL.djjdjlid
  is '主键';
comment on column DJJDJL.cjsj
  is '创建时间';
comment on column DJJDJL.je
  is '金额';
comment on column DJJDJL.lx
  is '类型';
comment on column DJJDJL.bz
  is '备注';
comment on column DJJDJL.yhzhxxid
  is '用户账户ID';
-- Create/Recreate primary, unique and foreign key constraints 
alter table DJJDJL
  add primary key (DJJDJLID)
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
