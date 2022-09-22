트랜잭션 -> 작업의 단위(모음), 일괄처리를 하기 위한 기준

COMMIT -> 정상적인 트랜잭션이 수행 되었을 때 
내용을 데이터베이스에 영구히 저장(DB 현 시점으로 유지)

ROLLBACK -> 비정상적인 트랜잭션이 수행 되었을 때
트랜잭션 이전 시점으로 취소(무결성 보장)

자동 COMMIT -> 새로운 트랜잭션이 수행되면 이전 
트랜잭션도 자동 저장
수동 COMMIT -> 명령문이나 트리거를 이용해 수동 저장

자동 ROLLBACK -> 비정상 종료
수동 ROLLBACK -> 명령문이나 트리거를 이용해 수동 롤백

INSERT INTO (TAB_NAME)
VALUES (DATA VALUES)

INSERT INTO (TAB_NAME(COL_NAME))
VALUES (DATA VALUES)

INTO 절에 명시된 컬럼의 개수, 순서, 데이터 타입과 길이에 맞게
VALUES 의 입력데이터가 1:1로 매칭

UPDATE (TAB_NAME)
SET (COL_NAME) = (VALUES)
WHERE (CONDITION)


DELETE UPDATE 
 - 




SELECT D.DEPARTMENT_ID, D.LOCATION_ID, COUNT(E.EMPLOYEE_ID), AVG(E.SALARY) AS AVGSAL
FROM DEPARTMENTS D, EMPLOYEES E
WHERE D.DEPARTMENT_ID = E.DEPARTMENT_ID
GROUP BY D.DEPARTMENT_ID, D.LOCATION_ID
ORDER BY D.LOCATION_ID;

33. 이름에 t를 포함하고 있는 사원과 같은 부서에 근무하는 사원의 
이름과 사원번호와 부서번호를 출력하시오.
SELECT LAST_NAME, EMPLOYEE_ID, DEPARTMENT_ID
FROM EMPLOYEES
WHERE DEPARTMENT_ID IN (
    SELECT DISTINCT DEPARTMENT_ID
    FROM EMPLOYEES
    WHERE LAST_NAME LIKE '%t%'
)
ORDER BY LAST_NAME;

34. 최저급여를 받는 사원보다 더 많은 급여를 받는 사원의 
이름과 급여를 출력하시오.
SELECT LAST_NAME, SALARY
FROM EMPLOYEES
WHERE SALARY > (
    SELECT MIN(SALARY)
    FROM EMPLOYEES
)
ORDER BY SALARY DESC;

35. 50번 부서의 평균급여보다 더 많은 급여를 받는 사원의 
이름과 급여와 부서번호를 출력하시오.
SELECT LAST_NAME, SALARY, DEPARTMENT_ID
FROM EMPLOYEES
WHERE SALARY > (
    SELECT AVG(SALARY)
    FROM EMPLOYEES
    WHERE DEPARTMENT_ID = 50
)
ORDER BY SALARY DESC;

36. 부서별 최대 급여를 받는 사원의 번호, 이름과 급여를 출력하시오.
SELECT DEPARTMENT_ID, EMPLOYEE_ID, LAST_NAME, SALARY
FROM EMPLOYEES
WHERE (DEPARTMENT_ID, SALARY) IN (
    SELECT DEPARTMENT_ID, MAX(SALARY)
    FROM EMPLOYEES
    GROUP BY DEPARTMENT_ID
)
ORDER BY DEPARTMENT_ID;

38. 시애틀에 근무하는 사람 중 커미션을 받지않는 모든 사람들의 이름, 
부서 명, 지역 ID를 출력하시오.
SELECT E.LAST_NAME, D.DEPARTMENT_ID, D.LOCATION_ID
FROM EMPLOYEES E, DEPARTMENTS D
WHERE E.DEPARTMENT_ID = D.DEPARTMENT_ID
AND D.LOCATION_ID = (
    SELECT LOCATION_ID
    FROM LOCATIONS
    WHERE CITY = 'Seattle'
)
AND E.COMMISSION_PCT IS NULL;


39. 이름이 Davies 인 사람보다 후에 고용된 사원들의 이름 및 
고용일자를 출력하시오. 고용일자를 역순으로 출력하시오.
SELECT LAST_NAME, HIRE_DATE
FROM EMPLOYEES
WHERE HIRE_DATE > (
    SELECT HIRE_DATE
    FROM EMPLOYEES
    WHERE LAST_NAME = 'Davies'
)
ORDER BY HIRE_DATE DESC;

40. King 을 매니저로 두고 있는 모든 사원들의 이름 및 급여를 출력하시오.
SELECT LAST_NAME, MANAGER_ID, SALARY
FROM EMPLOYEES
WHERE MANAGER_ID IN (
    SELECT EMPLOYEE_ID
    FROM EMPLOYEES
    WHERE LAST_NAME = 'King'
);

41. 회사 전체 평균급여보다 더 많이 받는 사원들 중 이름에 u가 있는 사원들이 
근무하는 부서에서 근무하는 사원들의 사번, 이름 및 급여를 출력하시오.
SELECT EMPLOYEE_ID, LAST_NAME, SALARY
FROM EMPLOYEES
WHERE DEPARTMENT_ID IN (
    SELECT DISTINCT DEPARTMENT_ID
    FROM EMPLOYEES
    WHERE LAST_NAME LIKE '%u%'
    AND SALARY > (
        SELECT AVG(SALARY)
        FROM EMPLOYEES
    )
)
ORDER BY SALARY DESC;

INSERT INTO DEPARTMENTS
VALUES (300, 'ITCENTER', 100, 1700);

INSERT INTO DEPARTMENTS
VALUES (310, 'ADMIN', 101, 1800);

INSERT INTO DEPARTMENTS(
    LOCATION_ID, DEPARTMENT_ID, DEPARTMENT_NAME, MANAGER_ID)
VALUES (1700, 100, 'ITCENTER', 10);

SELECT SYSDATE
FROM DUAL;

UPDATE EMPLOYEES
SET SALARY = 20000
WHERE EMPLOYEE_ID = 206;

DELETE FROM DEPARTMENTS
WHERE DEPARTMENT_NAME = 'Finance';

SELECT SALARY
FROM EMPLOYEES
WHERE EMPLOYEE_ID = 141;

UPDATE EMPLOYEES
SET SALARY = 20000
WHERE EMPLOYEE_ID = 141;