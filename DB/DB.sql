데이터의 생명주기
DB란? => 무결성이 보장된 데이터의 집합, 저장소
정보 : 수많은 데이터를 모아 가공하여 도출해낸 결과

*데이터 무결성
 - 데이터의 정확성, 가치/신뢰
 - 항상 데이터는 현재 시점이어야 함

테이블 : 데이터를 저장하는 단위(표의 구조)
 - 데이터를 분류하여 저장
 - 데이터의 무결성을 보장

컬럼 : 테이블을 구성하는 단계
 - 하나의 테이블은 여러개의 컬럼으로 구성
 - 하나의 분류, 컬럼별 특성에 맞는 데이터들을 저장

Primary key(기본 키)
 - 테이블을 대표하는 컬럼에 설치
 - 무결성을 보장하는 하나의 조건
 - Not null + Unique

Foreign key(참조 키)
 - 다른 테이블의 데이터를 참조
 - 테이블간 관계를 설정하여 무결성 보장
 - 종속적 삭제 방지
 - 검색 속도 향상

DBMS : DB 관리, 사용자 요청 처리

DB 특수문자
; : 문장 종결자
* : (ASTERISK) 전체를 의미
/ : SQL buffer에 저장된 명령문 text를 불러와 실행

*SQL문
데이터 검색
 - SELECT
데이터 조작어(DML)
 - INSERT, UPDATE, DELETE, MERGE
데이터 정의어(DDL)
 - CREATE, ALTER, DROP, RENAME, TRUNCATE
트랜잭션 제어
 - COMMIT, ROLLBACK, SAEPOINT
데이터 제어어(DCL)
 - GRANT, REVOKE

DEPARTMENTS : 부서 DATA
 DEPARTMENT_ID : 부서 번호(PK)
 DEPARTMENT_NAME : 부서 이름
 MANAGER_ID : 부서 관리자의 사원번호
 LOCATION_ID : 부서가 위치한 도시 지역 번호

EMPLOYEES : 사원 DATA
 EMPLOYEE_ID : 사원 번호
 HIRE_DATE : 고용된 날짜
 JOB_ID : 수행하는 업무
 SALARY : 급여
 COMMISSION_PCT : 보너스
 MANAGER_ID : 사수의 사원번호
 DEPARTMENT_ID : 근무중인 부서 번호(FK)

SQL+ LANG
COLUMN (COL_NAME) FORMAT ㅡ A(TEXT/DATE LENGTH) 
                         ㄴ 9(INTEGER)