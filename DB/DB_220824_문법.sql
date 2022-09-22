SELECT (COL_NAME) FROM (TAB_NAME);
Ex) SELECT DEPARTMENT_ID FROM DEPARTMENTS;

SELECT *(ALL_COL) FROM (TAB_NAME);

1. 작성 > 2. 해석 > 3. 예측 > 4. 실행 > 5. 결과 비교 > 6. 분석

*숫자 데이터 타입의 컬럼에서 산술 연산이 가능
Ex) SELECT SALARY*12 AS ANNUAL_SALARY FROM EMPLOYEES;
*DATE 타입에서는 +- 연산이 가능
Ex) SELECT HIRE_DATE + 7 FROM EMPLOYEES;

NVL(COL_NAME, VALUE) : COL_NAME 의 NULL 값을 VALUE 값으로 대체
Ex) SELECT LAST_NAME, SALARY*12*NVL(COMMISSION_PCT, 1) FROM EMPLOYEES;
(COL_NAME)*CALC AS (RENAME) : COL_NAME 을 RENAME 으로 대체
Ex) SELECT SALARY*12 AS ANNUAL_SALARY
AS는 생략 가능 *but 성능과 가독성을 위해 사용
Ex) SELECT SALARY*12 ANNUAL_SALARY
(COL_NAME) "(RENAME)" : COL_NAME 을 RENAME 으로 대체
AS 문과 다르게 대소문자를 구분함
Ex) SELECT SALARY*12 "Annual Salary"

DISTINCT : 중복된 VALUE 를 제외
그룹화 : 중복 제거를 위한 첫 작업

================================================
SELECT DISTINCT (COL_NAME) (RENAME) 
FROM (TAB_NAME) 
ORDER BY (RULES);

TAB_NAME 의 COL_NAME 에서 중복을 제거한 뒤 
RENAME 을 하고 RULES 대로 정렬
================================================
SELECT (COL_NAME) FROM (TAB_NAME) 
WHERE (LAST_NAME = 'Whalen');

CONDITION 의 VALUE 를 만족하는 COL_NAME 의 데이터를 SELECT
 - VALUE 가 문자값일 경우 '' 를 사용, 대소문자를 구분

WHERE (SALARY <= 3000)
 - VALUE 가 숫자값이 경우 '' 사용을 권장하지 않음
================================================