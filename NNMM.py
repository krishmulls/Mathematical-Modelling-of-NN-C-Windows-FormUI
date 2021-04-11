import numpy as np
import sys

def NNMM():
    WS = float(sys.argv[1])
    CS = float(sys.argv[2])
    LS = float(sys.argv[3])
    PS = float(sys.argv[4])
    GS = float(sys.argv[5])

    HLB = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]]
    if WS <= 50:
        HLB[0][0] = 1
    else:
        HLB[0][0] = 0
    if WS >= 50:
        HLB[0][1] = 1
    else:
        HLB[0][1] = 0
    if CS >= 1:
        HLB[0][2] = 1
    else:
        HLB[0][2] = 0
    if CS <= 1:
        HLB[0][3] = 1
    else:
        HLB[0][3] = 0
    if CS >= 3:
        HLB[0][4] = 1
    else:
        HLB[0][4] = 0
    if CS <= 3:
        HLB[0][5] = 1
    else:
        HLB[0][5] = 0
    if CS >= 2:
        HLB[0][6] = 1
    else:
        HLB[0][6] = 0
    if CS <= 2:
        HLB[0][7] = 1
    else:
        HLB[0][7] = 0
    if LS > 1:
        HLB[0][8] = 1
    else:
        HLB[0][8] = 0
    if LS >= 1:
        HLB[0][9] = 1
    else:
        HLB[0][9] = 0
    if LS <= 1:
        HLB[0][10] = 1
    else:
        HLB[0][10] = 0
    if PS > 1:
        HLB[0][11] = 1
    else:
        HLB[0][11] = 0
    if PS < 1:
        HLB[0][12] = 1
    else:
        HLB[0][12] = 0
    if GS < 50:
        HLB[0][13] = 1
    else:
        HLB[0][13] = 0
    if CS > 0:
        HLB[0][14] = 1
    else:
        HLB[0][14] = 0
    if GS > 50:
        HLB[0][15] = 1
    else:
        HLB[0][15] = 0
    if PS < 9999:
        HLB[0][16] = 1
    else:
        HLB[0][16] = 0

    WSL1 = [[1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]]

    WSL2 = [[1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1],
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]]

    WSL3 = [[1, 0, 0],
            [0, 1, 0],
            [0, 1, 0],
            [0, 0, 1],
            [1, 0, 0],
            [0, 0, 1],
            [1, 0, 0],
            [0, 0, 1],
            [0, 1, 0],
            [1, 0, 0],
            [0, 1, 0]]

    # layer 1
    B1 = [[0, 0, -1, -1, -1, 0, -1, 0, 0, 0, 0, 0, 0]]
    OLWB1 = np.matmul(HLB, WSL1)
    OL1 = OLWB1 + B1
    OLAA1 = OL1
    for x in range(0, 13):
        OLAA1[0][x] = Activation(OL1[0][x], 1)

    # layer2
    B2 = [[0, 0, 0, 0, 0, 0, -1, 0, 0, 0, -1]]
    OLWB2 = np.matmul(OLAA1, WSL2)
    OL2 = OLWB2 + B2
    OLAA2 = OL2
    for x in range(0, 11):
        OLAA2[0][x] = Activation(OL2[0][x], 1)

    # layer3

    B3 = [[0, 0, 0]]
    OLWB3 = np.matmul(OLAA2, WSL3)
    OL3 = OLWB3 + B3
    OLAA3 = OL3
    for x in range(0, 3):
        OLAA3[0][x] = Activation(OL3[0][x], 1);

    if ((OLAA3[0][0] >= 1 and (
            OLAA1[0][2] < 1 and OLAA1[0][3] < 1 and OLAA1[0][5] < 1 and OLAA1[0][8] < 1) and PS > 10 and GS > 50) or (
            OLAA3[0][1] == 1 and OLAA1[0][2] >= 1 and WS > 20) or (OLAA3[0][2] == 1)):
        if OLAA3[0][0] >= 1:
            if (OLAA1[0][2] < 1 and OLAA1[0][3] < 1 and OLAA1[0][5] < 1 and OLAA1[0][8] < 1):
                if PS > 10:
                    if GS > 50:
                        ret = "you can increase your speed"
                        print(ret)
        if (OLAA3[0][1] == 1 and OLAA1[0][2] >= 1 and WS > 20):
            ret = "you can decrease your speed"
            print(ret)
        if (OLAA3[0][2] == 1):
            ret = "you can see environment and apply brakes"
            print(ret)
    else:
        ret = "Maintain your speed and environment"
        print(ret)


def Activation(j, i):
    if j >= i:
        out = 1
    else:
        out = 0
    return out

if __name__ == "__main__":
    NNMM()
